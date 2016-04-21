using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Geo
{
    public class Region : IAddressFormatter
    {
        public Region(RegionType type, string code, string name, string shortName, Region containingRegion, IAddressFormatter formatter)
        {
            if (type != RegionType.Country && containingRegion == null)
            {
                throw new ArgumentNullException(nameof(containingRegion), "The top level region must be a country");
            }
            Code = code;
            Type = type;
            Name = name;
            ShortName = shortName;
            ContainingRegion = containingRegion;
            Formatter = formatter;
        }
        public string Name { get; }
        public RegionType Type { get; set; }
        public Region ContainingRegion { get; }
        public IAddressFormatter Formatter { get; }
        public string ShortName { get; }
        /// <summary>
        /// The code, according to Iso3166
        /// </summary>
        public string Code { get; private set; }

        public IEnumerable<string> Format(Address address)
        {
            var formatter = Formatter ?? ContainingRegion ?? AddressWriter.Default;
            return formatter.Format(address);
        }

        public IEnumerable<Region> GetRegions()
        {
            yield return this;
            if (ContainingRegion != null)
            {
                foreach (var region in ContainingRegion.GetRegions()) yield return region;
            }
        }
    }
}
