
using ASP.NET_CORE_WEB_API.Data;
using ASP.NET_CORE_WEB_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace ASP.NET_CORE_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ApplicationDBContext _context;
        public ProductController(ApplicationDBContext context)
        {
            _context = context;
        }

        //GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        //GET: api/Product/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            return product;

        }

        //POST: api/Product
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product pr)
        {
            _context.Products.Add(pr);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProducts), new { id = pr.Id }, pr);
        }

        //PUT: api/Product/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, Product pr)
        {
            

            var existing = await _context.Products.FindAsync(id);
            if (existing == null) return NotFound();

            // Gán lại từng field cần update
            existing.Name = pr.Name;
            existing.Price = pr.Price;
            existing.Description = pr.Description;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //DELETE: api/Product/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
