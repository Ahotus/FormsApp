using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormsApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FormsApp.Models;

namespace FormsApp.Controllers
{
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
    return View();
}

[HttpPost]
public async Task<IActionResult> Create(Product model, IFormFile imagefile)
{
    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
    if (!ModelState.IsValid)
    {
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View(model);
    }

    var extension = Path.GetExtension(imagefile.FileName);
    var randomFileName = $"{Guid.NewGuid().ToString()}{extension}";
    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);

    if (!allowedExtensions.Contains(extension) )
    {
        ModelState.AddModelError("ImageFile", "Lütfen sadece resim dosyası yükleyin.");
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View(model);
    }

    using (var stream = new FileStream(path, FileMode.Create))
    {
        await imagefile.CopyToAsync(stream);
    }

    model.Image = randomFileName;
    Repository.CreateProduct(model);

    ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
    return RedirectToAction("Index"); // Ürünü oluşturduktan sonra yönlendirme yap
}
    }
}
