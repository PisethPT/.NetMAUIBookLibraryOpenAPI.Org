using BookLibraryOpenAPI.Org.ViewModels;

namespace BookLibraryOpenAPI.Org;
public partial class MainPage : ContentPage
{
    public MainPage(BookViewModel bookViewModel)
    {
        InitializeComponent();
        BindingContext = bookViewModel;
    }
}



