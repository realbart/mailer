using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Mails
{
    public class EmailFactory : IMessageFactory
    {
        public Func<IEmailSender> SmtpClientCreator { get; set; } = () => new SmtpClientAdapter(new SmtpClient());


        public IMessage CreateMessage(string type)
        {
            return new Email(SmtpClientCreator());
        }
    }
}
