using System;

namespace Entities
{
    public class SiteVolume
    {
        public decimal Volume { get; set; }
        public long SiteId { get; set; }
        public DateTime BillingMonth { get; set; }
    }
}