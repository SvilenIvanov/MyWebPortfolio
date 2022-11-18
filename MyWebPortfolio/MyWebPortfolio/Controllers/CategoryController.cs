using MyWebPortfolio.Data;

using Microsoft.AspNetCore.Mvc;
using MyWebPortfolio.Models;

namespace MyWebPortfolio.Controllers {
    public class CategoryController : Controller {

        private readonly AppdDbContext _db;

        public CategoryController(AppdDbContext db) {
            _db = db;
        }

        public IActionResult Index() {
            IEnumerable<Category> categories = _db.Categories;
            return View(categories);
        }
        public IActionResult Create() { //GET
            return View();
        }

        public IActionResult Edit(int? id) {
            if(id == null || id == 0) {
                return NotFound();
            }
            Category? category = _db.Categories.Find(id);
            if(category == null) {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category) { //POST

            if(category.Name == category.DisplayOrder.ToString()) {

                ModelState.AddModelError("NameOrderMatchingError", "The display order can't exactly match the name.");
                //return View(category);
            }
            if (ModelState.IsValid) {
                try {
                    _db.Categories.Add(category);
                    _db.SaveChanges();
                } catch(Exception ex) {
                    Console.WriteLine(String.Format("Could not add category {0} to database: {1}", 
                        category, ex.Message));
                }
                return RedirectToAction("Index");
            }
            return View(category);
        }


    }
}
