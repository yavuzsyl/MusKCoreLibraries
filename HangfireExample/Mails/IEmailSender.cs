using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireExample.Mails
{
    public interface IEmailSender
    {
        Task Send(string mailAddress, string message);
    }
}
