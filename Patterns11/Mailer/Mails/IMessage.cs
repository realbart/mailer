using Mailer.Parties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Mails
{
    public interface IMessage: IDisposable
    {
        Party Sender { get; set; }

        Party Recipient { get; set; }

        string Subject { get; set; }

        IEnumerable<string> Body { get; set; }

        void Send();

    }
}
