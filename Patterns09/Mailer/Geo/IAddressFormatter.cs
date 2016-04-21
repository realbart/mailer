using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Geo
{
    /// <summary>
    /// FormattingBehavior
    /// </summary>
    public interface IAddressFormatter
    {
        IEnumerable<string> Format(Address address);
    }
}
