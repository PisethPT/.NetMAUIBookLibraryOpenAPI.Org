using BookLibraryOpenAPI.Org.Models;

namespace BookLibraryOpenAPI.Org.Services;
public interface IBookService
{
    Task<TrendingBookModel> GetTrendingBookAsync();
    Task<TrendingBookModel> GetTrendingBooksType(string type);
    Task<List<Languages>> GetLanguagesAsync();
}

