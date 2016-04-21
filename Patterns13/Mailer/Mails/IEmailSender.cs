using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Mails
{
    public interface IEmailSender: IDisposable
    {
        void Send(MailMessage email);
    }
}
