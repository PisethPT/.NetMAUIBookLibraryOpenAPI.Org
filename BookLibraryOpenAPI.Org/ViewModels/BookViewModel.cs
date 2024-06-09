
using BookLibraryOpenAPI.Org.Models;
using BookLibraryOpenAPI.Org.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace BookLibraryOpenAPI.Org.ViewModels;
public partial class BookViewModel : BaseViewModel
{
    public IBookService bookService { get; }
    [ObservableProperty]
    private TrendingBookModel? trendingBook;
    public ObservableCollection<Languages> Language { get; } = new();
    [ObservableProperty]
    private List<string> booksType = new() { "now", "daily", "weekly", "monthly", "yearly", "forever" };

    public BookViewModel(IBookService bookService)
    {
        this.bookService = bookService;
        _= GetTrendingBook();
        _= GetLanguages();
    }

    async Task GetLanguages()
    {
        try
        {
            var lagauges = await bookService.GetLanguagesAsync();
            if (lagauges!.Count() != 0)
                Language.Clear();
            foreach (var language in lagauges)
                Language.Add(language);
        }catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error", $"{ex.Message}", "OK");
        }
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
    async Task BookDetail(Work work)
    {
        await Shell.Current.GoToAsync($"{nameof(BookDetail)}", true,
            new Dictionary<string, object>
            {
                //{ nameof(BookDetail), new object()},
                {"Work", work},
            });
    }

}

