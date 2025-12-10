using cseresznye_XE6XKN.PcShopModels;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace softeng_zh.Controllers
{
    [Route("api/components")]
    [ApiController]
    public class ComponentsController : ControllerBase
    {
        // GET: api/<WebshopController>
        [HttpGet]
        public IActionResult Get()
        {
            PcShopContext context = new();

            return Ok(context.Components.ToList());
        }

        // GET api/<WebshopController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            PcShopContext context = new();

            var component = (from x in context.Components
                             where x.ComponentId == id
                             select x).FirstOrDefault();

            if (component == null) return NotFound("There is no component with id of" + id);

            return Ok(component);
        }
       

        // POST api/<WebshopController>
        [HttpPost]
        public IActionResult Post([FromBody]Component component)
        {

            PcShopContext context = new();

            context.Add(component);
            context.SaveChanges();
            return Ok(component);

        }

        // PUT api/<WebshopController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Component component)
        {
            PcShopContext context = new();

            var oldComponent = (from x in context.Components
                                where x.ComponentId == id
                                select x).FirstOrDefault();

            if (oldComponent == null) return NotFound("There is no component with id of" + id);

            oldComponent.Name = component.Name;
            oldComponent.Brand = component.Brand;
            oldComponent.Price = component.Price;
            oldComponent.Stock = component.Stock;
            oldComponent.CategoryId = component.CategoryId;

            context.SaveChanges();

            return Ok(oldComponent);


        }

        // DELETE api/<WebshopController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            PcShopContext context = new();

            var component = (from x in context.Components
                             where x.ComponentId == id
                             select x).FirstOrDefault();

            if (component == null) return NotFound("There is no component with id of" + id);

            context.Components.Remove(component);
            context.SaveChanges();

            return Ok();

        }
    }
}
