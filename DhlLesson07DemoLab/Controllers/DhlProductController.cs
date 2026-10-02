using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DhlLesson07DemoLab.Models;

namespace DhlLesson07DemoLab.Controllers
{
    public class DhlProductController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public DhlProductController(IWebHostEnvironment env)
        {
            _env = env;
        }

        private static List<DhlProduct> products = new List<DhlProduct>();

        private static List<DhlCategory> categories = new List<DhlCategory>
        {
            new DhlCategory { Id = 1, Name = "Điện thoại" },
            new DhlCategory { Id = 2, Name = "Laptop" },
            new DhlCategory { Id = 3, Name = "Phụ kiện" }
        };

        private void LoadCategories()
        {
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
        }

        private void ValidateCategory(DhlProduct model)
        {
            if (model.CategoryId.HasValue &&
                !categories.Any(c => c.Id == model.CategoryId.Value))
            {
                ModelState.AddModelError("CategoryId", "Danh mục không tồn tại trong danh sách");
            }
        }

        private void ValidateImageFile(DhlProduct model)
        {
            if (model.ImageFile != null)
            {
                var allowed = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
                var ext = Path.GetExtension(model.ImageFile.FileName).ToLower();
                if (!allowed.Contains(ext))
                {
                    ModelState.AddModelError("ImageFile",
                        "Chỉ chấp nhận file ảnh có đuôi .jpg, .jpeg, .png, .gif, .webp");
                }
            }
        }

        private string UploadImage(IFormFile file)
        {
            string folder = Path.Combine(_env.WebRootPath, "products");
            Directory.CreateDirectory(folder);

            string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            using (var stream = new FileStream(Path.Combine(folder, fileName), FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return fileName;
        }

        private void DeleteImage(string? fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return;

            string path = Path.Combine(_env.WebRootPath, "products", fileName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }

        public ActionResult Index()
        {
            ViewBag.Categories = categories;
            return View(products);
        }

        public ActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            ViewBag.CategoryName = categories
                .FirstOrDefault(c => c.Id == product.CategoryId)?.Name;
            return View(product);
        }

        public ActionResult Create()
        {
            LoadCategories();
            return View(new DhlProduct());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DhlProduct model)
        {
            ValidateCategory(model);
            ValidateImageFile(model);

            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(model);
            }

            model.Image = UploadImage(model.ImageFile);
            model.Id = products.Count == 0 ? 1 : products.Max(p => p.Id) + 1;
            products.Add(model);

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            LoadCategories();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DhlProduct model)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            ModelState.Remove("ImageFile");

            ValidateCategory(model);
            ValidateImageFile(model);

            if (!ModelState.IsValid)
            {
                model.Image = product.Image;
                LoadCategories();
                return View(model);
            }

            if (model.ImageFile != null)
            {
                DeleteImage(product.Image);
                product.Image = UploadImage(model.ImageFile);
            }

            product.Name = model.Name;
            product.Price = model.Price;
            product.SalePrice = model.SalePrice;
            product.CategoryId = model.CategoryId;
            product.Description = model.Description;

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                DeleteImage(product.Image);
                products.Remove(product);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}