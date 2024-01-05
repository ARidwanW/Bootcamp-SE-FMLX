using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;
using WebMVC.Persistence.Repository;

namespace WebMVC.Controllers;
[Area("Admin")]
public class ProductController : Controller
{
    private readonly IProductRepository _product;
    public ProductController(IProductRepository product)
    {
        _product = product;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _product.GetAll("Category");
        return View(products.ToList());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        if (!ModelState.IsValid)
        {
            TempData["Error"] = $"Create {product.ProductName} is Failed";
            return View(product);
        }
        _product.Add(product);
        await _product.SaveAsync();
        TempData["Success"] = $"Create {product.ProductName} is success";
        return RedirectToAction(nameof(Index), nameof(Product));
    }
}
