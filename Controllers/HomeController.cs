using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormsApp.Models;

namespace FormsApp.Controllers;

public class HomeController : Controller
{
   
public IActionResult Index(string searchString)
{
    var Products = Repository.Products;

    if (!string.IsNullOrEmpty(searchString))
    {
        ViewBag.SearchString = searchString;
        Products = Products.Where(p => p.Name.ToLower().Contains(searchString.ToLower())).ToList();
    }
    return View(Products);
}

    public IActionResult Privacy()
    {
        return View();
    }

    
}
