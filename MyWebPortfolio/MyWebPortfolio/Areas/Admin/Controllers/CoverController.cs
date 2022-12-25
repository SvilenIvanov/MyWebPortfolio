

using Microsoft.AspNetCore.Mvc;
using MyWebPortfolio.DataAccess.Data;
using MyWebPortfolio.DataAccess.Repository;
using MyWebPortfolio.DataAccess.Repository.IRepository;
using MyWebPortfolio.Models;

namespace MyWebPortfolio.Areas.Admin.Controllers;

[Area("Admin")]

public class CoverController : Controller
{

    private readonly IUnitOfWork _unitOfWork;

    public CoverController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Cover> covers = _unitOfWork.Cover.GetAll();
        return View(covers);
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Cover cover)
    {

        if (ModelState.IsValid)
        {
            try
            {
                _unitOfWork.Cover.Add(cover);
                _unitOfWork.Save();
                TempData["Success"] = "Cover was added successfully";
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Could not add Cover {0} to database. {1}",
                    cover, ex.Message));
                TempData["Unsuccessful"] = "Cover could not be added to database because:" + ex.Message;
            }
            return RedirectToAction("Index");
        }
        return View(cover);
    }

    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Cover? cover = _unitOfWork.Cover.GetFirstOrDefault(item => item.Id == id);

        if (cover == null)
        {
            return NotFound();
        }
        return View(cover);

    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Cover cover)
    {

        if (ModelState.IsValid)
        {
            try
            {
                _unitOfWork.Cover.Update(cover);

                _unitOfWork.Save();
                TempData["Success"] = "Cover was updated successfully";
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Could not update Cover {0} to database. {1}",
                    cover, ex.Message));
                TempData["Unsuccessful"] = "Cover could not be updated to database because:" + ex.Message;
            }
            return RedirectToAction("Index");
        }
        return View(cover);
    }

    public IActionResult Delete(int? id)
    { //get
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Cover? cover = _unitOfWork.Cover.GetFirstOrDefault(item => item.Id == id);

        if (cover == null)
        {
            return NotFound();
        }
        return View(cover);

    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    { //post
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Cover? cover = _unitOfWork.Cover.GetFirstOrDefault(item => item.Id == id);

        if (cover == null)
        {
            return NotFound();
        }
        try
        {
            _unitOfWork.Cover.Remove(cover);
            _unitOfWork.Save();
            TempData["Success"] = "Cover was deleted successfully";
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("Could not delete Cover {0} from database. {1}",
                cover, ex.Message));
            TempData["Unsuccessful"] = "Cover could not be deleted to database because:" + ex.Message;
        }

        return RedirectToAction("Index");
    }
}

