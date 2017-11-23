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
	public partial class CategoryDetailPage : ContentPage
	{
		private CategoryDetailViewModel viewModel;

		public CategoryDetailPage(CategoryDetailViewModel item)
		{
			InitializeComponent();
			BindingContext = viewModel = item;
		}

		private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			if (!(args.SelectedItem is Criterion item))
				return;

			await Navigation.PushAsync(new CriterionDetailPage(new CriterionDetailViewModel(item)));

			// Manually deselect item
			ItemsListView.SelectedItem = null;
		}
	}
}