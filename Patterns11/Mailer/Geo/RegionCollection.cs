using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Geo
{
    public class RegionCollection : IDictionary<string, Region>
    {
        public static IDictionary<string, Region> Current { get; set; } = new RegionCollection();

        private Dictionary<string, Region> regions = new Dictionary<string, Region>();

        private RegionCollection()
        {
            var nl = new Region(RegionType.Country, "NL", "Nederland", "NL", null, new DutchAddressFormatter());
            regions.Add(nl.Code, nl);
            var nlZh = new Region(RegionType.Province, "NL-ZH", "Zuid-Holland", "ZH", nl, null);
            regions.Add(nlZh.Code, nlZh);
            var nlNh = new Region(RegionType.Province, "NL-NH", "Noord-Holland", "NH", nl, null);
            regions.Add(nlNh.Code, nlNh);
            var nlUt = new Region(RegionType.Province, "NL-UT", "Utrecht", "UT", nl, null);
            regions.Add(nlUt.Code, nlUt);
            var nlNb = new Region(RegionType.Province, "NL-NB", "Noord-Brabant", "NB", nl, null);
            regions.Add(nlNb.Code, nlUt);
            var aw = new Region(RegionType.Country, "NL-AW", "Aruba", "AW", null, new DutchAddressFormatter());
            regions.Add(aw.Code, nl);
            var us = new Region(RegionType.Country, "US", "United States of America", "USA", null, AddressWriter.Default);
            regions.Add(us.Code, us);
            var usNy = new Region(RegionType.State, "US-NY", "New York", "NY", us, null);
            regions.Add(usNy.Code, usNy);
            var usWa = new Region(RegionType.State, "US-WA", "Washington", "WA", us, null);
            regions.Add(usWa.Code, usWa);
            var usTx = new Region(RegionType.State, "US-TX", "Washington", "TX", us, null);
            regions.Add(usTx.Code, usTx);
            var gb = new Region(RegionType.Country, "GB", "Great Britain", "GB", null, AddressWriter.Default);
            regions.Add(gb.Code, gb);
            var gbFln = new Region(RegionType.Province, "GB-FLN", "Flintshire", "FLN", gb, null);
            regions.Add(gbFln.Code, gbFln);
        }

        Region IDictionary<string, Region>.this[string key]
        {
            get { return regions[key]; }
            set { regions[key] = value; }
        }


        int ICollection<KeyValuePair<string, Region>>.Count
        {
            get { return regions.Count; }
        }

        bool ICollection<KeyValuePair<string, Region>>.IsReadOnly
        {
            get { return false; }
        }

        ICollection<string> IDictionary<string, Region>.Keys
        {
            get { return regions.Keys; }
        }

        ICollection<Region> IDictionary<string, Region>.Values
        {
            get { return regions.Values; }
        }

        void ICollection<KeyValuePair<string, Region>>.Add(KeyValuePair<string, Region> item)
        {
            ((ICollection<KeyValuePair<string, Region>>)regions).Add(item);
        }

        void IDictionary<string, Region>.Add(string key, Region value)
        {
            regions.Add(key, value);
        }

        void ICollection<KeyValuePair<string, Region>>.Clear()
        {
            regions.Clear();
        }

        bool ICollection<KeyValuePair<string, Region>>.Contains(KeyValuePair<string, Region> item)
        {
            return ((ICollection<KeyValuePair<string, Region>>)regions).Contains(item);
        }

        bool IDictionary<string, Region>.ContainsKey(string key)
        {
            return regions.ContainsKey(key);
        }

        void ICollection<KeyValuePair<string, Region>>.CopyTo(KeyValuePair<string, Region>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<string, Region>>)regions).CopyTo(array, arrayIndex);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return regions.GetEnumerator();
        }

        IEnumerator<KeyValuePair<string, Region>> IEnumerable<KeyValuePair<string, Region>>.GetEnumerator()
        {
            return regions.GetEnumerator();
        }

        bool ICollection<KeyValuePair<string, Region>>.Remove(KeyValuePair<string, Region> item)
        {
            return ((ICollection<KeyValuePair<string, Region>>)regions).Remove(item);
        }

        bool IDictionary<string, Region>.Remove(string key)
        {
            return regions.Remove(key);
        }

        bool IDictionary<string, Region>.TryGetValue(string key, out Region value)
        {
            return regions.TryGetValue(key, out value);
        }
    }
}
