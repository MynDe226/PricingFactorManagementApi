using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PricingFactorManagementApi.DbSet;

namespace PricingFactorManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetByCountryCodeController : ControllerBase
    {
        private readonly PricingDbContext _context;

        public GetByCountryCodeController(PricingDbContext context)
        {
            _context = context;
        }

        [HttpPost()]
        public async Task<ActionResult<PricingFactorModel>> GetByCustomer([FromBody] PricingFactorRequest request)
        {
            var pricingFactor = await (from p in _context.PricingFactors
                                       where p.Date < request.Date && p.CountryCode == request.CountryCode && p.ProductGroup == request.ProductGroup
                                       select new PricingFactorModel
                                       {
                                           Factor = p.Factor,
                                           Date = p.Date
                                       }).OrderByDescending(f => f.Date).FirstOrDefaultAsync().ConfigureAwait(false);

            if (pricingFactor == null)
            {
                return NotFound();
            }

            return pricingFactor;
        }
    }
}
