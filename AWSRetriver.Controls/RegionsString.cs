using System;
using System.Collections.Generic;
using Amazon;

namespace AWSRetriver.Controls
{
    public class RegionsString
    {
        private readonly List<RegionEndpoint> items = new List<Amazon.RegionEndpoint>();

        public List<RegionEndpoint> Items => items;

        public void AddDisplayName(string displayName)
        {
            foreach (RegionEndpoint region in RegionEndpoint.EnumerableAllRegions)
            {
                if (region.DisplayName == displayName)
                {
                    Items.Add(region);
                }
            }
        }

        public static RegionsString All()
        {
            RegionsString rs = new RegionsString();
            foreach (RegionEndpoint region in RegionEndpoint.EnumerableAllRegions)
            {
                rs.items.Add(region);
            }
            return rs;
        }

        public void AddSystemName(string systemName)
        {
            foreach (RegionEndpoint region in RegionEndpoint.EnumerableAllRegions)
            {
                if (region.SystemName== systemName)
                {
                    Items.Add(region);
                }
            }
        }

        public void RemoveSystemName(string systemName)
        {            
            for (int i = 0; i < items.Count; i++)
            {
                if (this.items[i].SystemName == systemName)
                {
                    this.items.RemoveAt(i);
                    return;
                }
            }
        }

        public static RegionsString ParseSystemNames(string systemNames)
        {
            RegionsString rs = new RegionsString();            
            foreach (string term in systemNames.Split(' '))
            {
                rs.AddSystemName(term);                
            }
            return rs;
        }

        public string Text()
        {
            var items = new List<string>();
            foreach (var r in this.items)
            {
                items.Add(r.SystemName);
            }
            items.Sort();
            return string.Join(" ", items);
        }
    }
}