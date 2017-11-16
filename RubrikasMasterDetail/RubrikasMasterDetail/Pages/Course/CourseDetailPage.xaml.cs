using RubrikasMasterDetail.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RubrikasMasterDetail.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CourseDetailPage : ContentPage
	{
		public CourseDetailPage ()
		{
			InitializeComponent ();
		}

		public CourseDetailPage(CourseDetailViewModel item)
		{
			InitializeComponent ();

		}
	}
}