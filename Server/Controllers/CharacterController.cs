using Microsoft.AspNetCore.Mvc;
using RickServer.Models;
using System.Collections.Generic;
namespace RickServer.Controllers;

[ApiController]
[Route("[controller]")]
public class CharacterController : ControllerBase
{
    private readonly DataContext _db;

    public CharacterController(DataContext db) {
        _db = db;
    }

    private List<GetAllCharacters> getAllCharactersDb(int id) {
        var allcharacter = _db.GetAllCharacter.FirstOrDefault(c => c.Id == id);
        var characters = _db.Characters.ToList();
        var info = _db.Infos.ToList();
        var origin = _db.Origins.ToList();
        var location = _db.Locations.ToList();
        
        return new List<GetAllCharacters> {allcharacter};
    }

    [HttpGet]
    public IEnumerable<GetAllCharacters> Get() {
        if (Request.Query.ContainsKey("page") && int.TryParse(Request.Query["page"], out int page)) {
            return getAllCharactersDb(page);
        } 
        return getAllCharactersDb(1);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id) {
        var character = _db.Characters.FirstOrDefault(c => c.Id == id);

        if (character != null) {
            var Origin = _db.Origins.ToList();
            var Location = _db.Locations.ToList();
            return Ok(character);
        }
        return NotFound();
    }

}
