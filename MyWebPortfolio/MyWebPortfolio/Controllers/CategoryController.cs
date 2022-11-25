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
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category) {

            if(category.Name == category.DisplayOrder.ToString()) {

                ModelState.AddModelError("NameOrderMatchingError", "The display order can't exactly match the name.");
            }
            if (ModelState.IsValid) {
                try {
                    _db.Categories.Add(category);
                    _db.SaveChanges();
                    TempData["Success"] = "Category was added successfully";
                } catch(Exception ex) {
                    Console.WriteLine(String.Format("Could not add category {0} to database. {1}", 
                        category, ex.Message));
                    TempData["Unsuccessful"] = "Category could not be added to database because:" + ex.Message;
                }
                return RedirectToAction("Index");
            }
            return View(category);
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
        public IActionResult Edit(Category category) {

            if (category.Name == category.DisplayOrder.ToString()) {

                ModelState.AddModelError("NameOrderMatchingError", "The display order can't exactly match the name.");
            }
            if (ModelState.IsValid) {
                try {
                    _db.Categories.Update(category);
                    
                    _db.SaveChanges();
                    TempData["Success"] = "Category was updated successfully";
                }
                catch (Exception ex) {
                    Console.WriteLine(String.Format("Could not update category {0} to database. {1}",
                        category, ex.Message));
                    TempData["Unsuccessful"] = "Category could not be updated to database because:" + ex.Message;
                }
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Delete(int? id) { //get
            if (id == null || id == 0) {
                return NotFound();
            }
            Category? category = _db.Categories.Find(id);

            if (category == null) {
                return NotFound();
            }
            return View(category);

        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id) { //post
            if (id == null || id == 0) {
                return NotFound();
            }
            Category? category = _db.Categories.Find(id);

            if (category == null) {
                return NotFound();
            }
            try {
                _db.Categories.Remove(category);
                _db.SaveChanges();
                TempData["Success"] = "Category was deleted successfully";
            }
            catch (Exception ex) {
                Console.WriteLine(String.Format("Could not delete category {0} from database. {1}",
                    category, ex.Message));
                TempData["Unsuccessful"] = "Category could not be deleted to database because:" + ex.Message;
            }

            return RedirectToAction("Index");
        }
    }
}
