using HangfireExample.BackgroundJobs;
using HangfireExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HangfireExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //FireAndForgetJobs.SendEmailToUser("mailAddress", "halo");

            return View();
        }

        public IActionResult ImageUpload()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ImageUpload(IFormFile formFile)
        {
            BackgroundJobs.RecurringJobs.ReportingJob();
            var newFileName = string.Empty;
            if (formFile != null && formFile.Length > 0)
            {
                newFileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/", "images", newFileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }

                var delayedJobId = BackgroundJobs.DelayedJobs.AddWaterMarkJob(newFileName, "halo");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
