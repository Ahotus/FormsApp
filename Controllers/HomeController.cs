using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormsApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace FormsApp.Controllers;

public class HomeController : Controller
{
   
public IActionResult Index(string searchString, string category)
{
    var products = Repository.Products;

    if (!string.IsNullOrEmpty(searchString))
    {
        ViewBag.SearchString = searchString;
        products = products.Where(p => p.Name!.ToLower().Contains(searchString.ToLower())).ToList();
    }
    if (!string.IsNullOrEmpty(category))
    {
        products = products.Where(p => p.CategoryId == int.Parse(category)).ToList();
    }

    var viewModel = new ProductViewModel
    {
        Products = products,
        Categories = Repository.Categories,
        SelectedCategory = category
    };

    // ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name", category);

    var model = new ProductViewModel
    {
        Products = products,
        Categories = Repository.Categories,
        SelectedCategory = category
    };
    return View(model);


    
}

[HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        // Your logic here
        return View();
    }


    [HttpPost]
    public IActionResult Create(Product model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
            return View(model);
        }
        Repository.CreateProduct(model);
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View(model);
    }

    
}
