using Mailer.Parties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Mails
{
    public class MailAddressAdapter : MailAddress
    {
        public MailAddressAdapter(Party party) : base(party.EMail, party.Name) { }
    }
}
