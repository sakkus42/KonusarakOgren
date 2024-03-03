namespace RickServer.Models;
using Newtonsoft.Json;

public class ApiCharacter {
    protected bool isTheDbFull = false;
    protected string? apiUrl;

    public ApiCharacter(string url) {
        this.apiUrl = url;
        using (var db = new DataContext()) {
            if (db.GetAllCharacter.Count() != 0) this.isTheDbFull = true;
        }
    }
    public async Task GetApi() {
        Console.WriteLine("GetApi() Char");
        using HttpClient client = new HttpClient();

        try {
            HttpResponseMessage response = await client.GetAsync(this.apiUrl);
            if (response.IsSuccessStatusCode) {
                string responseBody = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<GetAllCharacters>(responseBody);
                using (var db = new DataContext()) {
                    db.Add(new GetAllCharacters() {Info = data.Info, Results = data.Results});
                    db.SaveChanges();
                }
                this.apiUrl = data?.Info?.next;
                
            } else {
                Console.WriteLine("API Error");
            }
        } catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public bool endPage() {
        if (this.apiUrl != null) return false;
        return true;
    }

    public bool DbFull() { return this.isTheDbFull; }
}

public class ApiEpisode : ApiCharacter {
    public ApiEpisode(string url) : base(url) {
        this.apiUrl = url;
        using (var db = new DataContext()) {
            if (db.GetAllEpisode.Count() != 0) this.isTheDbFull = true;
            else this.isTheDbFull = false;
        }
    }

    public new async Task GetApi() {
        Console.WriteLine("GetApi() Episode");
        using HttpClient client = new HttpClient();

        try {
            HttpResponseMessage response = await client.GetAsync(this.apiUrl);
            if (response.IsSuccessStatusCode) {
                string responseBody = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<GetAllEpisodes>(responseBody);
                using (var db = new DataContext()) {
                    db.Add(new GetAllEpisodes() {Info = data?.Info, Results = data?.Results});
                    db.SaveChanges();
                }
                this.apiUrl = data?.Info?.next;
                
            } else {
                Console.WriteLine("API Error");
            }
        } catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}