using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RubrikasMasterDetail.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RubrikasMasterDetail.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GradeCategory : ContentPage
	{
		private GradeCategoryViewModel viewModel;

		public GradeCategory(GradeCategoryViewModel viewModel, bool connected = true)
		{
			InitializeComponent ();
			BindingContext = this.viewModel = viewModel;
		}
	}
}