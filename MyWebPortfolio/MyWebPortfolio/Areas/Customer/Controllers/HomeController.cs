﻿using Microsoft.AspNetCore.Mvc;
using MyWebPortfolio.DataAccess.Repository;
using MyWebPortfolio.DataAccess.Repository.IRepository;
using MyWebPortfolio.Models;
using System.Diagnostics;

namespace MyWebPortfolio.Areas.Customer.Controllers;
[Area("Customer")]

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Product> productsList = _unitOfWork.Product.GetAll(includeProperties: "Category,Cover");

        return View(productsList);
    }

    public IActionResult Privacy()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}