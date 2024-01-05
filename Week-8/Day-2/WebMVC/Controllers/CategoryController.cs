using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMVC.Data;
using WebMVC.Models;

namespace WebMVC.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;
    public CategoryController(ApplicationDbContext context)
    {
        _db = context;
    }

    public async Task<IActionResult> Index()
    {
        var category = await _db.Categories.ToListAsync();
        return View(category);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Category category)
    {
        if(!ModelState.IsValid)
        {
            return View(category);
        }
        _db.Categories.Add(category);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index), nameof(category));
    }

    [HttpGet]
    public async Task<IActionResult> Update(Guid id)
    {
        var category = await _db.Categories.FindAsync(id);
        return View(category);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Category category)
    {
        if(!ModelState.IsValid)
        {
            return View(category);
        }

        _db.Categories.Update(category);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        var category = await _db.Categories.FindAsync(id);
        return View(category);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Category category)
    {
        _db.Categories.Remove(category);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }


}
