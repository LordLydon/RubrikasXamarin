using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RubrikasMasterDetail.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RubrikasMasterDetail.Models;

namespace RubrikasMasterDetail.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CriterionDetailPage : ContentPage
	{
		private CriterionDetailViewModel viewModel;

		public CriterionDetailPage(CriterionDetailViewModel item)
		{
			InitializeComponent();
			BindingContext = viewModel = item;
		}
	}
}