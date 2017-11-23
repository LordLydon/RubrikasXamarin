using RubrikasMasterDetail.Models;
using RubrikasMasterDetail.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RubrikasMasterDetail.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CourseDetailPage : TabbedPage
	{
		private CourseDetailViewModel viewModel;
		
		public CourseDetailPage(CourseDetailViewModel item, bool connected = true)
		{
			InitializeComponent ();
			BindingContext = viewModel = item;
			GenerateChildren(connected);
		}

		private void GenerateChildren(bool connected = true)
		{
			var evaluationsPage = new EvaluationsPage(viewModel.Course, connected);
			var studentsPage = new StudentsPage(viewModel.Course, connected);
			
			Children.Add(evaluationsPage);
			Children.Add(studentsPage);
		}
	}
}