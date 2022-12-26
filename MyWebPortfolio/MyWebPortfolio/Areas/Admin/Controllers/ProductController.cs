

using Microsoft.AspNetCore.Mvc;
using MyWebPortfolio.DataAccess.Data;
using MyWebPortfolio.DataAccess.Repository;
using MyWebPortfolio.DataAccess.Repository.IRepository;
using MyWebPortfolio.Models;

namespace MyWebPortfolio.Areas.Admin.Controllers;

[Area("Admin")]

public class ProductController : Controller
{

    private readonly IUnitOfWork _unitOfWork;

    public ProductController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Product> categories = _unitOfWork.Product.GetAll();
        return View(categories);
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Product product)
    {

        if (ModelState.IsValid)
        {
            try
            {
                _unitOfWork.Product.Add(product);
                _unitOfWork.Save();
                TempData["Success"] = "Product was added successfully";
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Could not add product {0} to database. {1}",
                    product, ex.Message));
                TempData["Unsuccessful"] = "Product could not be added to database because:" + ex.Message;
            }
            return RedirectToAction("Index");
        }
        return View(product);
    }

    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Product? product = _unitOfWork.Product.GetFirstOrDefault(item => item.Id == id);

        if (product == null)
        {
            return NotFound();
        }
        return View(product);

    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Product product)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _unitOfWork.Product.Update(product);

                _unitOfWork.Save();
                TempData["Success"] = "Product was updated successfully";
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Could not update product {0} to database. {1}",
                    product, ex.Message));
                TempData["Unsuccessful"] = "Product could not be updated to database because:" + ex.Message;
            }
            return RedirectToAction("Index");
        }
        return View(product);
    }

    public IActionResult Delete(int? id)
    { //get
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Product? product = _unitOfWork.Product.GetFirstOrDefault(item => item.Id == id);

        if (product == null)
        {
            return NotFound();
        }
        return View(product);

    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    { //post
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Product? product = _unitOfWork.Product.GetFirstOrDefault(item => item.Id == id);

        if (product == null)
        {
            return NotFound();
        }
        try
        {
            _unitOfWork.Product.Remove(product);
            _unitOfWork.Save();
            TempData["Success"] = "Product was deleted successfully";
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("Could not delete product {0} from database. {1}",
                product, ex.Message));
            TempData["Unsuccessful"] = "Product could not be deleted to database because:" + ex.Message;
        }

        return RedirectToAction("Index");
    }
}

