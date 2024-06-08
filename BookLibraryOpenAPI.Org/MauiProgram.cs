using BookLibraryOpenAPI.Org.Query;
using BookLibraryOpenAPI.Org.Services;
using BookLibraryOpenAPI.Org.ViewModels;
using BookLibraryOpenAPI.Org.Views;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace BookLibraryOpenAPI.Org
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddTransient<MainPage>();

            builder.Services.AddHttpClient<IBookService, BookService>();
            builder.Services.AddTransient<BookViewModel>();

            builder.Services.AddTransient<BookDetail>();
            builder.Services.AddTransient<BookDetailViewModel>();

            return builder.Build();
        }
    }
}
