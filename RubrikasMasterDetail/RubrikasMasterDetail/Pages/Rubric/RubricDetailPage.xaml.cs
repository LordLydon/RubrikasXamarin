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
	public partial class RubricDetailPage : ContentPage
	{
		private RubricDetailViewModel viewModel;

		public RubricDetailPage(RubricDetailViewModel item)
		{
			InitializeComponent();
			BindingContext = viewModel = item;
		}
	}
}