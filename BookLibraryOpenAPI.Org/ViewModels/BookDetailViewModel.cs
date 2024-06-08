using BookLibraryOpenAPI.Org.Models;
using BookLibraryOpenAPI.Org.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BookLibraryOpenAPI.Org.ViewModels;
[QueryProperty(nameof(BookDetail),"TrendingBook")]
public partial class BookDetailViewModel : BaseViewModel
{
    [ObservableProperty]
    TrendingBookModel? trendingBook;

    [RelayCommand]
    Task Back() => Shell.Current.GoToAsync("..");
}

