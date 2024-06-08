using BookLibraryOpenAPI.Org.Views;

namespace BookLibraryOpenAPI.Org
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(BookDetail), typeof(BookDetail));
        }
    }
}
