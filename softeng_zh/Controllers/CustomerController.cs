using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cseresznye_XE6XKN.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        [HttpPost]
        public IActionResult Post([FromBody] PcShopModels.Customer customer)
        {
            PcShopModels.PcShopContext context = new();
            context.Add(customer);
            context.SaveChanges();
            return Ok(customer);

        }
    }
}
