using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Geo
{
    public class RegionFactory
    {
        public static RegionFactory Current { get; set; } = new RegionFactory();

        public Region this[string key]
        {
            get
            {
                switch (key)
                {
                    case "NL-ZH":
                        {
                            var nl = new Region(RegionType.Country, "NL", "Nederland", "NL", null, new DutchAddressFormatter());
                            return new Region(RegionType.Province, "NL-ZH", "Zuid-Holland", "ZH", nl, null);
                        }
                    case "NL-UT":
                        {
                            var nl = new Region(RegionType.Country, "NL", "Nederland", "NL", null, new DutchAddressFormatter());
                            return new Region(RegionType.Province, "NL-UT", "Utrecht", "UT", nl, null);
                        }
                    case "GB-FLN":
                        {
                            var nl = new Region(RegionType.Country, "GB", "Great Britain", "GB", null, AddressWriter.Default);
                            return new Region(RegionType.Province, "GB-FLN", "Flintshire", "FL", nl, null);
                        }
                }
                throw new IndexOutOfRangeException(key);
            }
        }
    }
}
