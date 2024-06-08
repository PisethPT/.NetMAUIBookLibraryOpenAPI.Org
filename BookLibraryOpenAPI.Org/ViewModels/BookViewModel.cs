
using BookLibraryOpenAPI.Org.Models;
using BookLibraryOpenAPI.Org.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace BookLibraryOpenAPI.Org.ViewModels;
public partial class BookViewModel : BaseViewModel
{
    public IBookService bookService { get; }
    [ObservableProperty]
    private TrendingBookModel? trendingBook;
    [ObservableProperty]
    private List<string> booksType = new() { "now", "daily", "weekly", "monthly", "yearly", "forever" };

    public BookViewModel(IBookService bookService)
    {
        this.bookService = bookService;
        _= GetTrendingBook();
    }

    async Task GetTrendingBook()
    {
        try
        {
            IsBusy = true;
            TrendingBook = await bookService.GetTrendingBookAsync();
            IsBusy = false;
        }catch (Exception ex)
        {
            IsBusy = true;
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error",$"{ex.Message}","OK");
        }
    }

    [RelayCommand]
    async Task GetTrendingBookType(string type)
    {
        try
        {
            IsBusy = true;
            TrendingBook = await bookService.GetTrendingBooksType(type);
            IsBusy = false;
        }
        catch (Exception ex)
        {
            IsBusy = true;
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error", $"{ex.Message}", "OK");
        }
    }

    [RelayCommand]
    async Task BookDetail(TrendingBookModel trendingBook)
    {
        await Shell.Current.GoToAsync($"{nameof(BookDetail)}", true,
            new Dictionary<string, object>
            {
                //{ nameof(BookDetail), new object()},
                {$"{nameof(BookDetail)}", trendingBook},
            });
    }

}

