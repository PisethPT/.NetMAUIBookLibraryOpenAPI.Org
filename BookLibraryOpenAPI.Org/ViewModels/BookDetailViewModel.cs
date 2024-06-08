using BookLibraryOpenAPI.Org.Models;
using BookLibraryOpenAPI.Org.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BookLibraryOpenAPI.Org.ViewModels;
[QueryProperty("Work", "Work")]
public partial class BookDetailViewModel : BaseViewModel
{
    [ObservableProperty]
    Work? work;

    [RelayCommand]
    Task Back() => Shell.Current.GoToAsync("..");
}

