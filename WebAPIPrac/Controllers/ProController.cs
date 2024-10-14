using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIPrac.Data;
using WebAPIPrac.Models;

namespace WebAPIPrac.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public ProController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet("Product List")]
        public IActionResult Index()
        {
            var data = db.Pro.ToList();
            return Ok(data);
        }
        [HttpPost("AddProdcut")]
        public IActionResult AddProduct(Products p)
        {
            db.Pro.Add(p);
            db.SaveChanges();
            return Ok("Product Added Successfully");
        }
        [HttpPut]
        public IActionResult EditProduct( Products p ,int id)
        {
            var data = db.Pro.Find(id);
            if(data == null)
            {
                return NotFound();
            }
            data.Pname = p.Pname;
            data.Pcat = p.Pcat;
            data.Price = p.Price;
            db.Pro.Update(data);
            db.SaveChanges();
            return Ok("Product Update Successfully");
            
        }
        [HttpDelete]
        [Route("DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            var data = db.Pro.Find(id);
            if(data == null)
            {
                return NotFound();
            }
            db.Pro.Remove(data);
            db.SaveChanges();
            return Ok("Product Deleted Successfully");
        }

        [HttpGet]
        [Route("GetProuductByName")]
        public IActionResult GetProduct(string name)
        {
            var data = db.Pro.Where(p=>p.Pname.Equals(name)).ToList();
            return Ok(data);
        }

        [HttpDelete]
        [Route("MultipleDelete")]
        public IActionResult MultiDelete(List<int> ids)
        {
            var data = db.Pro.Where(p=>ids.Contains(p.Id)).ToList();
            if(data == null)
            {
                return NotFound();
            }
            db.Pro.RemoveRange(data);   
            db.SaveChanges();
            return Ok("Products Deleted Successfully");

        }
    }
}
