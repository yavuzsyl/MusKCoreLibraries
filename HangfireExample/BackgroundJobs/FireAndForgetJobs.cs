using HangfireExample.Mails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireExample.BackgroundJobs
{
    //fail olan job 10 kere tekrar eder
    public class FireAndForgetJobs
    {
        public static void SendEmailToUser(string mailAddress, string message)
        {
           var identifier = Hangfire.BackgroundJob.Enqueue<IEmailSender>(x => x.Send(mailAddress, message));
        }
    }
}
