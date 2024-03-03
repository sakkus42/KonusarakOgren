namespace RickServer.Models;

public class Info {
    public int  Id      { get; set; }
    public int Count    { get; set; }
    public int Pages    { get; set; }
    public string? next { get; set; }
    public string? prev { get; set; }
}

public class Character {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public string Species { get; set; }
    public string Type { get; set; }
    public string Gender { get; set; }
    public int? OriginId { get; set; }
    public int? LocationId { get; set; }
    public Origin Origin { get; set; }
    public Location Location { get; set; }
    public string Image { get; set; }
    public List<string> Episode { get; set; }
    public string Url { get; set; }
    public DateTime Created { get; set; }

    
};


public class Origin {
    public int Id       { get; set; }
    public string? Name { get; set; }
    public string? Url  { get; set; }

}

public class Location { 
    public int Id       { get; set; }
    public string? Name { get; set; }
    public string? Url  { get; set; }
}

public class Episode {
    public int Id                   { get; set; }
    public string? Name             { get; set; }
    public string? Air_date         { get; set; }
    public string? episode          { get; set; }
    public List<string>? characters  { get; set; }
    public string? Url              { get; set; }
    public DateTime Created         { get; set;}

}

// CHARACTERS
public class GetAllCharacters {
    public int  Id                  { get; set; }
    public Info? Info                { get; set; }
    public List<Character>? Results  { get; set; }
}

// EPISODE

public class GetAllEpisodes {
    public int  Id                  { get; set; }
    public Info? Info                { get; set; }
    public List<Episode>? Results  { get; set; }
}

