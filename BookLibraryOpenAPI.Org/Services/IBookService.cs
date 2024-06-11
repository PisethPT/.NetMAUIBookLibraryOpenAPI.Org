using BookLibraryOpenAPI.Org.Models;

namespace BookLibraryOpenAPI.Org.Services;
public interface IBookService
{
    Task<TrendingBookModel> GetTrendingBookAsync();
    Task<List<Languages>> GetLanguagesAsync(); // from directory json file
    Task<TrendingBookModel> GetTrendingBooksType(string type);
    Task<TrendingBookModel?> GetBooksNow(string type);

}

