using Hangfire;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireExample.BackgroundJobs
{
    public class RecurringJobs
    {
        public static void ReportingJob()
        {
            Hangfire.RecurringJob.AddOrUpdate("recurringjob1", () => EmailReport(), Cron.Minutely);
        }
        public static void EmailReport()
        {
            Debug.WriteLine("Rapor, gönderildi");
        }
    }
}
