using cseresznye_XE6XKN.PcShopModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace softeng_zh.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // GET: api/<OrdersController>
        [HttpGet]
        public IActionResult Get()
        {
            PcShopContext context = new();

            return Ok(context.OrderHeaders.ToList());
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            PcShopContext context = new();

            var order = (from x in context.OrderHeaders
                         where x.OrderId == id
                         select x).FirstOrDefault();

            if (order == null) return NotFound("No order with id of" + id);

            return Ok(order);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public IActionResult ChangeStatus(int id, [FromBody]string status)
        {

            PcShopContext context = new();

            var orderOld = (from x in context.OrderHeaders
                         where x.OrderId == id
                         select x).FirstOrDefault();

            if (orderOld == null) return NotFound("No order with id of" + id);

            orderOld.Status = status;

            context.SaveChanges();

            return Ok(orderOld);



        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            PcShopContext context = new();
            var order = (from x in context.OrderHeaders
                         where x.OrderId == id
                         select x).FirstOrDefault();
            if (order == null) return NotFound("No order with id of" + id);
            context.OrderHeaders.Remove(order);
            context.SaveChanges();
            return Ok();
        }

    }
}
