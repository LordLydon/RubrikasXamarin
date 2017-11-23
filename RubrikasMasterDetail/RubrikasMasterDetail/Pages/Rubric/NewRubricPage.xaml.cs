using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RubrikasMasterDetail.Models;
using RubrikasMasterDetail.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RubrikasMasterDetail.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewRubricPage : ConnectedContentPage
	{
		private NewRubricViewModel viewModel { get; set; }

		public NewRubricPage(bool connected = true) : base(connected)
		{
			InitializeComponent();

			BindingContext = viewModel = new NewRubricViewModel();
		}

		private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			if (!(args.SelectedItem is Category item))
				return;

			await Navigation.PushAsync(new NewCategoryPage(new NewCategoryViewModel(item)));

			// Manually deselect item
			ItemsListView.SelectedItem = null;
		}

		private async void AddItem_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewCategoryPage());
		}

		async void Save_Clicked(object sender, EventArgs e)
		{
			if (IsConnected)
			{
				if (Rubric.IsValid(viewModel.Item))
				{
					MessagingCenter.Send(this, "AddItem", viewModel.Item);
					await Navigation.PopToRootAsync();
				}
				else
				{
					await DisplayAlert("Error",
						"Todos los campos son requeridos y la suma de los pesos de las categorias debe ser 100%!", "OK");
				}
			}
			else
			{
				DisplayNotConnectedError();
			}
		}

		protected override void SwitchConnectedFeatures()
		{
		}
	}
}