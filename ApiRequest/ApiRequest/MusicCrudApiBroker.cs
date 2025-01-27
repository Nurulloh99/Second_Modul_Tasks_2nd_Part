using System.Text;
using System.Text.Json;

namespace ApiRequest;

public class MusicCrudApiBroker
{
    private HttpClient _httpClient;
    private string _baseUrl;

    public MusicCrudApiBroker()
    {
        _baseUrl = "https://localhost:7035/api/Music";
        _httpClient = new HttpClient();

        //GetAll();
        //Add();
        //GetById();
        //Delete();
        //Update();
    }


    public void GetAll()
    {
        var url = $"{_baseUrl}/GetAllMusic";

        HttpResponseMessage response = _httpClient.GetAsync(url).Result;
        string responseContent = response.Content.ReadAsStringAsync().Result;

        response.EnsureSuccessStatusCode();

        JsonSerializerOptions options = new JsonSerializerOptions();
        options.PropertyNameCaseInsensitive = true;

        var music = JsonSerializer.Deserialize<Music[]>(responseContent, options);

        foreach (var m in music)
        {
            Console.WriteLine(m);
        }

    }


    public void Add()
    {
        var url = $"{_baseUrl}/AddMusic";
        var music = new Music()
        {
            Name = "Austranaut",
            MB = 12,
            AuthorName = "Nurulloh",
            Description = "Judda yaxshi",
            QuentityLikes = 90000
        };

        var json = JsonSerializer.Serialize(music);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = _httpClient.PostAsync(url, content).Result;
        response.EnsureSuccessStatusCode();

        var responseContend = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(responseContend);
    }


    public void GetById()
    {

        Guid id = new Guid("2e3a9bfa-11c3-40fe-a89c-75b5d41ec9b1");
        var url = $"{_baseUrl}/GetMusicById/{id}";

        HttpResponseMessage response = _httpClient.GetAsync(url).Result;
        response.EnsureSuccessStatusCode();

        string responseContent = response.Content.ReadAsStringAsync().Result;

        JsonSerializerOptions options = new JsonSerializerOptions();
        options.PropertyNameCaseInsensitive = true;

        var music = JsonSerializer.Deserialize<Music>(responseContent, options);
        Console.WriteLine(music);
    }


    public void Delete()
    {

        Guid id = new Guid("");
        var url = $"{_baseUrl}/DeleteMusic/{id}";

        HttpResponseMessage response = _httpClient.DeleteAsync(url).Result;
        response.EnsureSuccessStatusCode();

        string responseContent = response.Content.ReadAsStringAsync().Result;

        var finish = 0;
    }




    public void Update()
    {
        var url = $"{_baseUrl}/UpdateMusic";
        var music = new Music()
        {
            Id = new Guid("231e5a3d-4be3-43be-8507-cd8f429a4197"),
            Name = "nothing",
            MB = 17,
            AuthorName = "noooothing",
            Description = "no",
            QuentityLikes = 9
        };

        var json = JsonSerializer.Serialize(music);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = _httpClient.PutAsync(url, content).Result;
        response.EnsureSuccessStatusCode();

        var responseContend = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(responseContend);
    }

}
