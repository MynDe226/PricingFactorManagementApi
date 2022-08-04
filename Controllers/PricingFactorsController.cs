using Microsoft.AspNetCore.Mvc;
using PricingFactorManagementApi.DbSet;

namespace PricingFactorManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingFactorsController : ControllerBase
    {
        private readonly PricingDbContext _context;

        public PricingFactorsController(PricingDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<PricingFactor>> PostPricingFactor([FromBody] AddFactorRequest request)
        {
            if (!ValidateRequest(request))
            {
                return BadRequest();
            }
            var result = new PricingFactor()
            {
                CustomerNumber = request.CustomerNumber,
                CountryCode = request.CountryCode,
                ProductGroup = request.ProductGroup,
                Date = request.Date,
                Factor = request.Factor
            };
            _context.PricingFactors.Add(result);
            await _context.SaveChangesAsync();

            return Ok(result);
        }
        
        private bool ValidateRequest(AddFactorRequest r)
        {
           return (r.CountryCode == null && r.CustomerNumber != null) || _context.CountryCodes.Any(x => x.Code == r.CountryCode);
        }
    }
}
