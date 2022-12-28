

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWebPortfolio.DataAccess.Data;
using MyWebPortfolio.DataAccess.Repository;
using MyWebPortfolio.DataAccess.Repository.IRepository;
using MyWebPortfolio.Models;
using MyWebPortfolio.Models.ViewModels;
using NuGet.Versioning;

namespace MyWebPortfolio.Areas.Admin.Controllers;

[Area("Admin")]

public class ProductController : Controller {

    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _hostEnvironment;

    public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment) {
        _unitOfWork = unitOfWork;
        _hostEnvironment = hostEnvironment;
    }

    public IActionResult Index() {
        IEnumerable<Cover> objCovers = _unitOfWork.Cover.GetAll();
        return View(objCovers);
    }


    //GET
    public IActionResult Upsert(int? id) {
        ProductVM productVM = new() {
            Product = new(),
            CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem {
                Text = i.Name,
                Value = i.Id.ToString()
            }),
            CoverTypeList = _unitOfWork.Cover.GetAll().Select(i => new SelectListItem {
                Text = i.Name,
                Value = i.Id.ToString()
            }),
        };

        if (id == null || id == 0) {
            //create product
            //ViewBag.CategoryList = CategoryList;
            //ViewData["CoverTypeList"] = CoverTypeList;
            return View(productVM);
        }
        else {
            productVM.Product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
            return View(productVM);

            //update product
        }


    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(ProductVM obj, IFormFile? file) {

        if (ModelState.IsValid) {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            if (file != null) {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"images\products");
                var extension = Path.GetExtension(file.FileName);

                if (obj.Product.ImageURL != null) {
                    var oldImagePath = Path.Combine(wwwRootPath, obj.Product.ImageURL.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath)) {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create)) {
                    file.CopyTo(fileStreams);
                }
                obj.Product.ImageURL = @"\images\products\" + fileName + extension;

            }
            if (obj.Product.Id == 0) {
                _unitOfWork.Product.Add(obj.Product);
            }
            else {
                _unitOfWork.Product.Update(obj.Product);
            }
            _unitOfWork.Save();
            TempData["success"] = "Product created successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    public IActionResult Delete(int? id) { //get
        if (id == null || id == 0) {
            return NotFound();
        }
        Product? product = _unitOfWork.Product.GetFirstOrDefault(item => item.Id == id);

        if (product == null) {
            return NotFound();
        }
        return View(product);

    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id) { //post
        if (id == null || id == 0) {
            return NotFound();
        }
        Product? product = _unitOfWork.Product.GetFirstOrDefault(item => item.Id == id);

        if (product == null) {
            return NotFound();
        }
        try {
            _unitOfWork.Product.Remove(product);
            _unitOfWork.Save();
            TempData["Success"] = "Product was deleted successfully";
        }
        catch (Exception ex) {
            Console.WriteLine(string.Format("Could not delete product {0} from database. {1}",
                product, ex.Message));
            TempData["Unsuccessful"] = "Product could not be deleted to database because:" + ex.Message;
        }

        return RedirectToAction("Index");
    }
}

