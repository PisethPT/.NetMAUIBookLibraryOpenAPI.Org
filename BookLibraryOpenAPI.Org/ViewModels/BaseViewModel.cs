using CommunityToolkit.Mvvm.ComponentModel;

namespace BookLibraryOpenAPI.Org.ViewModels;
public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isBusy;
}

