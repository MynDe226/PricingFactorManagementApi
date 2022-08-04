using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PricingFactorManagementApi.DbSet;

namespace PricingFactorManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetByCustomerController : ControllerBase
    {
        private readonly PricingDbContext _context;

        public GetByCustomerController(PricingDbContext context)
        {
            _context = context;
        }

        [HttpPost()]
        public async Task<ActionResult<PricingFactorModel>> GetByCustomer([FromBody] PricingFactorRequest request)
        {
            var pricingFactor = await (from p in _context.PricingFactors
                                       where p.Date < request.Date && p.CustomerNumber == request.CustomerId && p.ProductGroup == request.ProductGroup
                                       orderby p.Date descending, p.CountryCode descending
                                       select new PricingFactorModel
                                         {
                                             Factor = p.Factor,
                                             Date = p.Date
                                         }).FirstOrDefaultAsync().ConfigureAwait(false);

            if (pricingFactor == null)
            {
                return NotFound();
            }

            return pricingFactor;
        }
    }
}
