using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMVC.Data;
using WebMVC.Models;
using WebMVC.Persistence.Repository;

namespace WebMVC.Controllers;
[Area("Admin")]
public class CategoryController : Controller
{
    private readonly ICategoryRepository _category;
    public CategoryController(ICategoryRepository context)
    {
        _category = context;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _category.GetAll();
        return View(categories.ToList());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Category category)
    {
        if (!ModelState.IsValid)
        {
            TempData["Error"] = $"Create {category.CategoryName} is Failed";
            return View(category);
        }
        _category.Add(category);
        await _category.SaveAsync();
        TempData["Success"] = $"Create {category.CategoryName} is success";
        return RedirectToAction(nameof(Index), nameof(category));
    }

    [HttpGet]
    public async Task<IActionResult> Update(Guid id)
    {
        var category = await _category.Get(id);
        if(category == null)
        {
            TempData["Error"] = "No category found";
            return RedirectToAction(nameof(Index));
        }
        return View(category);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Category category)
    {
        if (!ModelState.IsValid)
        {
            TempData["Error"] = $"Update {category.CategoryName} is Failed";
            return View(category);
        }

        _category.Update(category);
        await _category.SaveAsync();
        TempData["Success"] = $"Update {category.CategoryName} is success";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        var category = await _category.Get(id);
        return View(category);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Category category)
    {
        _category.Remove(category);
        await _category.SaveAsync();
        TempData["Success"] = $"Delete success";
        return RedirectToAction(nameof(Index), nameof(Category));
    }


}
