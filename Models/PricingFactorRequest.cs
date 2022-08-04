namespace PricingFactorManagementApi
{
    public class PricingFactorRequest
    {
        public long? CustomerId { get; set; }
        public string ProductGroup { get; set; }
        public string? CountryCode { get; set; }
        public DateTime Date { get; set; }
    }
}
