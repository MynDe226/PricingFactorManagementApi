namespace PricingFactorManagementApi
{
    public class AddFactorRequest
    {
        public long? CustomerNumber { get; set; }
        public string? CountryCode { get; set; }
        public long Factor { get; set; }
        public DateTime Date { get; set; }
        public string ProductGroup { get; set; }
    }
}
