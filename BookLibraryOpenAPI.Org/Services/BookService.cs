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
    private TrendingBookModel booksNow { get; set; }

    public BookService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<TrendingBookModel> GetTrendingBookAsync()
    {
        var trending_today = "trending/daily.json";
        var uri = $"{main_url}{trending_today}";
        var response = await httpClient.GetAsync(uri);
        trendingBook = await GetResponse(response);

        return trendingBook;
    }

    public async Task<TrendingBookModel> GetTrendingBooksType(string type)
    {
        var uri = $"{main_url}trending/{type}{jsonExtension}";
        var response = await httpClient.GetAsync(uri);
        trendingBook = await GetResponse(response);
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

    public async Task<TrendingBookModel> GetBooksNow(string type)
    {
        var uri = $"{main_url}{type}";
        var response = await httpClient.GetAsync(uri);
        booksNow = await GetResponse(response);
        await Shell.Current.DisplayAlert("Error", $"{response.StatusCode }{booksNow.works.Count}", "OK");
        return booksNow;
    }



    // get response method
    private async Task<TrendingBookModel> GetResponse(HttpResponseMessage response)
    {
        TrendingBookModel trendingBookModel = new TrendingBookModel();
        if (response.IsSuccessStatusCode)
             trendingBookModel = await response.Content.ReadFromJsonAsync<TrendingBookModel>();
        return trendingBookModel;
    }
}

