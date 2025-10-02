using ASP.NET_MVC_Basic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET_MVC_Basic.Controllers
{
    public class ProductController : Controller
    {

        private static List<Product> dsSanpham = new() {
            new Product{MaSP=1, TenSP="iPhone 16", Gia=18500000},
            new Product{MaSP=2, TenSP="iPhone 17", Gia=21500000}
        };

        //GET: product
        public IActionResult Index()
        {
            return View(dsSanpham);
        }

        //GET: /product/create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //GET: /product/update
        [HttpGet]
        public IActionResult Update(int id)
        {
            var sp = dsSanpham.FirstOrDefault(p => p.MaSP == id);
            if(sp == null) return NotFound();
            return View(sp);
        }
        [HttpPost]
        public IActionResult Update(Product pr)
        {
            var sp = dsSanpham.FirstOrDefault(p => p.MaSP == pr.MaSP);
            if(sp == null) return NotFound();
            if (ModelState.IsValid)
            {
                sp.TenSP = pr.TenSP;
                sp.Gia = pr.Gia;
                return RedirectToAction("Index");
            }
            return View(pr);
        }

        //POST: /product/create
        [HttpPost]
        public IActionResult Create(Product pr)
        {
            if (ModelState.IsValid)
            {
                pr.MaSP = dsSanpham.Count + 1;
                dsSanpham.Add(pr);
                return RedirectToAction("Index");
            }
            return View(pr);
        }

        //Xóa sản phẩm
        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            var sp = dsSanpham.FirstOrDefault(p => p.MaSP == id);
            if (sp == null) return NotFound();
            dsSanpham.Remove(sp);
            return RedirectToAction("Index");
        }
    }
}
