using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Mailer.Mails;

namespace MailerTests.TestDoubles
{
    public class EmailSenderSpy : IEmailSender
    {
        public void Dispose()
        {
        }

        public void Send(MailMessage email)
        {
            MailMessage = email;
        }

        public MailMessage MailMessage { get; set; }
    }
}
