using RubrikasMasterDetail.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RubrikasMasterDetail.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CourseDetailPage : TabbedPage
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