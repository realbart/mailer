using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer
{
    public static class Utility
    {
        public static IEnumerable<TTarget> EmptyIfNull<TTarget>(this IEnumerable<TTarget> target)
        {
            return target ?? Enumerable.Empty<TTarget>();
        }
    }
}
