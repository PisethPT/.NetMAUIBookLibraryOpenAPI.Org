using BookLibraryOpenAPI.Org.ViewModels;

namespace BookLibraryOpenAPI.Org;
public partial class MainPage : ContentPage
{
    private int deviceSize = 0;
    public MainPage(BookViewModel bookViewModel)
    {
        InitializeComponent();
        BindingContext = bookViewModel;
        deviceSize = (int) GetDevicesType();
       // Shell.Current.DisplayAlert("Trending Frame Size", $"{deviceSize}", "Ok");
        if (deviceSize > 0 && deviceSize <= 890)
        {
            TrendingGrid.Span = 1;
            OtherBooksGrid.Span = 2;
        }
        //}else if(deviceSize >0 && deviceSize == 1646)
        //{
        //    TrendingGrid.Span = 2;
        //    OtherBooksGrid.Span = 4;
        //}
    }

    private double GetDevicesType()
    {
        double autoFrameHeight = 0;

        if (Device.RuntimePlatform == Device.Android)
        {
            var androidWindow = Platform.CurrentActivity.Window;
            var metrics = new Android.Util.DisplayMetrics();
            androidWindow.WindowManager.DefaultDisplay.GetMetrics(metrics);
            autoFrameHeight = metrics.HeightPixels / metrics.Density;
        }
        return autoFrameHeight;
    }
}



