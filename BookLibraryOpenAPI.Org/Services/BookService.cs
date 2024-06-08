using BookLibraryOpenAPI.Org.Models;
using System.Net.Http.Json;

#nullable disable
namespace BookLibraryOpenAPI.Org.Services;
internal class BookService : IBookService
{
    private readonly HttpClient httpClient;
    private const string main_url = "https://openlibrary.org/";
    private readonly string jsonExtension = ".json";
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

    public Task<Languages> GetLanguagesAsync()
    {
        throw new NotImplementedException();
    }
}

