using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HangfireExample.Mails
{
    //Sendgrid https://sendgrid.com/
    public class EmailSender : IEmailSender
    {
        IConfiguration _configuration;
        public EmailSender(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public async Task Send(string mailAddress, string message)
        {
            
            var apiKey = _configuration.GetSection("APIKeys")["SendGrid"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("yavuzsoyl@outlook.com");
            var subject = "Hangfire";
            var to = new EmailAddress("yavuzsyl@gmail.com");
            var plainText = message;
            var htmlContent = $"<strong> {message} </strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainText, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
