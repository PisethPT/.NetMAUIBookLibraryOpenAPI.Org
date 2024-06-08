using BookLibraryOpenAPI.Org.ViewModels;

namespace BookLibraryOpenAPI.Org.Views;

public partial class BookDetail : ContentPage
{
	public BookDetail(BookDetailViewModel bookDetail)
	{
		InitializeComponent();
		BindingContext = bookDetail;
	}
}