using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyWebPortfolio.Controllers {
    public class CoverController : Controller {
        // GET: CoverController
        public ActionResult Index() {
            return View();
        }

        // GET: CoverController/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: CoverController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: CoverController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        // GET: CoverController/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: CoverController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        // GET: CoverController/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: CoverController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }
    }
}
