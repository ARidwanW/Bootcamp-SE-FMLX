using System.Xml.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Model;
using WebAPI.Model.Request;
using WebAPI.Model.Response;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly MyDatabase _db;
    private readonly IMapper _map;
    public CategoryController(MyDatabase myDatabase, IMapper mapper)
    {
        _map = mapper;
        _db = myDatabase;
    }

    // [HttpGet]
    // public async Task<IActionResult> GetCategory()
    // {
    //     var categories = await _db.Categories.ToListAsync();
    //     if (categories.Count == 0)
    //     {
    //         return NotFound();
    //     }
    //     List<CategoryResponse> response = new();
    //     foreach(var category in categories) 
    // 	{
    // 		response.Add(new CategoryResponse()
    // 		{
    // 			CategoryId = category.CategoryId,
    // 			CategoryName = category.CategoryName,
    // 			Description = category.Description
    // 		});
    // 	}
    //     return Ok(response);
    // }

    [HttpGet]
    public async Task<IActionResult> GetCategory()
    {
        var categories = await _db.Categories.ToListAsync();
        if (categories.Count == 0)
        {
            return NotFound();
        }
        List<CategoryResponse> response = _map.Map<List<CategoryResponse>>(categories);
        return Ok(response);
    }

    [HttpGet]   //* localhost:port/api/category/{id}
    [Route("{id}")]
    public async Task<IActionResult> GetCategory([FromRoute] int id)
    {
        var category = await _db.Categories.FindAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        CategoryResponse response = _map.Map<CategoryResponse>(category);
        // return Ok(category);
        return Ok(response);
    }

    // [HttpPost]
    // public async Task<IActionResult> CreateCategory([FromBody] Category categories)
    // {
    //     _db.Categories.Add(category);
    //     await _db.SaveChangesAsync();
    //     return Ok(category);
    // }

    // [HttpPost]
    // public async Task<IActionResult> CreateCategory([FromBody] CategoryRequest request)
    // {
    //     var category = new Category()
    //     {
    //         CategoryName = request.CategoryName,
    //         Description = request.Description
    //     };
    //     _db.Categories.Add(category);
    //     await _db.SaveChangesAsync();
    //     return Ok(category);
    // }
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryRequest request)
    {
        Category category = _map.Map<Category>(request);
        _db.Categories.Add(category);
        await _db.SaveChangesAsync();
        return Ok(category);
    }

    [HttpPut]   //* localhost:port/api/category/{id} body: CategoryResponse
    [Route("{id}")]
    public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] CategoryRequest request)
    {
        Category category = await _db.Categories.FindAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        category.CategoryName = request.CategoryName;
        category.Description = request.Description;
        var response = _map.Map<CategoryResponse>(category);
        _db.Categories.Update(category);
        await _db.SaveChangesAsync();
        return Ok(response);
    }

    //! error
    // [HttpPut]   //* localhost:port/api/category/{id} body: CategoryResponse
    // [Route("{id}")]
    // public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] Category cat)
    // {
    //     Category category = await _db.Categories.FindAsync(id);
    //     if (category == null)
    //     {
    //         return NotFound();
    //     }
    //     category = _map.Map<Category>(cat);
    //     _db.Categories.Update(category);
    //     await _db.SaveChangesAsync();
    //     return Ok(category);
    // }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteCategory([FromRoute] int id)
    {
        Category category = await _db.Categories.FindAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        _db.Categories.Remove(category);
        await _db.SaveChangesAsync();
        return Ok(category);
    }
}
