using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Mails
{
    public class SmtpClientAdapter : IEmailSender
    {
        private SmtpClient _client;

        public SmtpClientAdapter(SmtpClient client)
        {
            _client = client;
        }

        public void Send(MailMessage email)
        {
            _client.Send(email);
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
