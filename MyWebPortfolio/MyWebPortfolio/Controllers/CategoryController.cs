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
    }
}
