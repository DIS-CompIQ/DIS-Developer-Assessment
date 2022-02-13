using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FugaziImporter.Models;

namespace FugaziImporter.Controllers;

[ApiController]
[Route("[controller]")]
public class FugaziController : ControllerBase {
    // public readonly ILogger<FugaziController> _logger;

    // public FugaziController(ILogger<FugaziController> logger){
    //     _logger = logger;
    // }

    private readonly FugaziContext _context;

    public FugaziController(FugaziContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<FugaziImport>>> GetAllFgzImported(){
        return await _context.FugaziImport.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FugaziImport>> GetFgzImportedById(int id){
        var fugazi = await _context.FugaziImport.FindAsync(id);

        if (fugazi == null) {
            return NotFound();
        }

        return fugazi;
    }
}