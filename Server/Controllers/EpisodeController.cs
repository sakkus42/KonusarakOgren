using Microsoft.AspNetCore.Mvc;
using RickServer.Models;
using System.Collections.Generic;
namespace RickServer.Controllers;

[ApiController]
[Route("[controller]")]
public class EpisodeController : ControllerBase
{
    private readonly DataContext _db;

    public EpisodeController(DataContext db) {
        _db = db;
    }

    private List<GetAllEpisodes> getAllEpisodesDb(int id) {
        var allEpisodes = _db.GetAllEpisode.FirstOrDefault(c => c.Id == id);
        var episodes = _db.Episodes.ToList();
        var info = _db.Infos.ToList();
        
        return new List<GetAllEpisodes> {allEpisodes};
    }

    [HttpGet]
    public IEnumerable<GetAllEpisodes> Get() {
        if (Request.Query.ContainsKey("page") && int.TryParse(Request.Query["page"], out int page)) {
            return getAllEpisodesDb(page);
        } 
        return getAllEpisodesDb(1);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id) {
        var episode = _db.Episodes.FirstOrDefault(c => c.Id == id);

        if (episode != null) {
            return Ok(episode);
        }
        return NotFound();
    }

}
