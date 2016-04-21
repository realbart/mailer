using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Mails
{
    public interface IMessageFactory
    {
        IMessage CreateMessage(string type);
    }
}
