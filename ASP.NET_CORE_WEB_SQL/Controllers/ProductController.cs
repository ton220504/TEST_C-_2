using ASP.NET_CORE_WEB_SQL.Data;
using ASP.NET_CORE_WEB_SQL.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CORE_WEB_SQL.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ProductController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        //List sản phẩm, giao diện hiển thị sản phẩm
        public IActionResult Index()
        {
            var dsSanpham = _context.Products.ToList();
            return View(dsSanpham);
        }


        //giao diện trang Create
        public IActionResult Create()
        {
            return View();
        }
        //giao diện trang Update
        public IActionResult Update(int id)
        {
            var ds = _context.Products.FirstOrDefault(sp => sp.Id == id);
            if (ds == null) return NotFound();
            return View(ds);
        }
        //-----------------------------------------------------------------------------------------------------------------------------
        //hàm thêm ảnh
        private string SaveImage(IFormFile imageFile)
        {
            var fileName = Guid.NewGuid().ToString()+ Path.GetExtension(imageFile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
            using(var stream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }

            return "/images/" + fileName;
        }

        //hàm cập nhật lại ảnh
        private void UpdateImage(IFormFile imageFile, Product pro)
        {
            if (imageFile == null || imageFile.Length == 0) return;
            if (!string.IsNullOrEmpty(pro.ImagePath)){
                var oldImagePath = Path.Combine(_env.WebRootPath, "images", Path.GetFileName(pro.ImagePath));
                if (System.IO.File.Exists(oldImagePath))
                    System.IO.File.Delete(oldImagePath);
            }

            pro.ImagePath = SaveImage(imageFile);
        }
        
        // POST
        [HttpPost]
        public IActionResult Create(Product pr, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if(imageFile != null || imageFile.Length > 0)
                {
                    var imagePath = SaveImage(imageFile);
                    pr.ImagePath = imagePath;
                }
                _context.Products.Add(pr);
                _context.SaveChanges();
                TempData["Message"] = "Thêm thành công";
                return RedirectToAction("Index");
            }
            return View(pr);
        }
        //UPDATE
        [HttpPost, ActionName("Update")]
        public IActionResult Update(Product pr, IFormFile? imageFile)
        {
            var ds = _context.Products.FirstOrDefault(sp => sp.Id == pr.Id);
            if (ds == null) return NotFound();

            if (ModelState.IsValid)
            {
                ds.Name = pr.Name;
                ds.Price = pr.Price;
                ds.Description = pr.Description;

                if (imageFile != null && imageFile.Length > 0)
                {
                    UpdateImage(imageFile, ds);
                }
                else
                {
                    ds.ImagePath = ds.ImagePath;
                }

                _context.Update(ds);
                _context.SaveChanges();

                TempData["Message"] = "Cập nhật thành công!";
                return RedirectToAction("Index");
            }

            pr.ImagePath = ds.ImagePath;
            return View(pr);
        }



        //DELETE
        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            var ds = _context.Products.FirstOrDefault(x => x.Id == id);
            if (ds == null) return NotFound();
            if (!string.IsNullOrEmpty(ds.ImagePath))
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", Path.GetFileName(ds.ImagePath));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }
            _context.Products.Remove(ds);
            _context.SaveChanges();
            TempData["Message"] = "Xóa thành công!";
            return RedirectToAction("Index");
        }
    }
}
