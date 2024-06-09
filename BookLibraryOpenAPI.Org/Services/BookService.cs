using BookLibraryOpenAPI.Org.Models;
using System.Net.Http.Json;
using System.Text.Json;

#nullable disable
namespace BookLibraryOpenAPI.Org.Services;
internal class BookService : IBookService
{
    private readonly HttpClient httpClient;
    private const string main_url = "https://openlibrary.org/";
    private readonly string jsonExtension = ".json";
    private List<Languages> languages { get; set; }

    private TrendingBookModel trendingBook { get; set; }

    public BookService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    public async Task<TrendingBookModel> GetTrendingBookAsync()
    {
        var trending_today = "trending/daily.json";
        var uri = $"{main_url}{trending_today}";
        var response = await httpClient.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            trendingBook = await response.Content.ReadFromJsonAsync<TrendingBookModel>();
           // await Shell.Current.DisplayAlert("Response", $"{response.StatusCode}", "OK");
        }

        return trendingBook;
    }

    public async Task<TrendingBookModel> GetTrendingBooksType(string type)
    {
        var uri = $"{main_url}trending/{type}{jsonExtension}";
        var response = await httpClient.GetAsync(uri);
        if (response.IsSuccessStatusCode)
            trendingBook = await response.Content.ReadFromJsonAsync<TrendingBookModel>();
        return trendingBook;
    }

    // read languages data from json file inside project
    public async Task<List<Languages>> GetLanguagesAsync()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("languages.json");
        using var reader = new StreamReader(stream);
        var content = await reader.ReadToEndAsync();
        languages = JsonSerializer.Deserialize<List<Languages>>(content);
        return languages;
    }
}

