using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using FugaziImporter.Models;


namespace FugaziImporter.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class FugaziController : ControllerBase {
    /*public readonly ILogger<FugaziController> _logger;

    public FugaziController(ILogger<FugaziController> logger){
        _logger = logger;
    }*/

    private readonly FiContext _context;

    public FugaziController(FiContext context) =>
        _context = context;


    [HttpGet]

    public async Task<List<FugaziImport>> Get() =>
        await _context.FugaziImport.ToListAsync();
    /*public ActionResult GetAllFgzImported(){
       
        return BadRequest("Not Implemented");
    }*/

    [HttpGet("{id}")]
    /*public ActionResult GetFgzImportedById(int id){
        return BadRequest($"Not implemented: {id}");
    }*/

    public async Task<ActionResult<FugaziImport>> Get(int id)
    {
        var item = await _context.FugaziImport.FindAsync(id);

        if (item is null)
        {
            return NotFound();
        }

        return item;
    }

    // <snippet_Create>
    /// <summary>
    /// Creates a TodoItem.
    /// </summary>
    /// <param name="item"></param>
    /// <returns>A newly created TodoItem</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///        "id": 1,
    ///        "name": "Item #1",
    ///        "isComplete": true
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>

}