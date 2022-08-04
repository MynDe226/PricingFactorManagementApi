using System;
using System.Collections.Generic;

namespace PricingFactorManagementApi.DbSet
{
    public partial class PricingFactor
    {
        public long Id { get; set; }
        public long? CustomerNumber { get; set; }
        public string? CountryCode { get; set; }
        public long Factor { get; set; }
        public DateTime Date { get; set; }
        public string ProductGroup { get; set; } = null!;
    }
}
