
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
    [ObservableProperty]
    private TrendingBookModel? bookNow;
    public ObservableCollection<Languages> Language { get; } = new();
    [ObservableProperty]
    private List<string> booksType = new() { "now", "daily", "weekly", "monthly", "yearly", "forever" };

    Random random = new Random();

    public BookViewModel(IBookService bookService)
    {
        this.bookService = bookService;
        _= GetTrendingBook();
       // _= GetLanguages();
    }

    async Task GetLanguages()
    {
        try
        {
            var laguages = await bookService.GetLanguagesAsync();
            if (laguages!.Count() != 0)
                Language.Clear();
            foreach (var language in laguages)
                Language.Add(language);

            await GetBooksNow();
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

    async Task GetBooksNow()
    {
        try
        {
            int index = 0;
            if(Language.Count > 0)
            index = random.Next(0, Language.Count);
            await Shell.Current.DisplayAlert("Connection", $"{index}", "OK");

            BookNow = await bookService.GetBooksNow(Language[index].key);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error", $"{ex.Message}", "OK");
        }
    }


    // Command

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

