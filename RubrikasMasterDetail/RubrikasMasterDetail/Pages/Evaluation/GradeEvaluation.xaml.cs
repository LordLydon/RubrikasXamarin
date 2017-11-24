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
	public partial class GradeEvaluation : ContentPage
	{
		private GradeEvaluationViewModel viewModel;

		public GradeEvaluation (GradeEvaluationViewModel viewModel, bool connected = true)
		{
			InitializeComponent ();
			BindingContext = this.viewModel = viewModel;
		}
	}
}