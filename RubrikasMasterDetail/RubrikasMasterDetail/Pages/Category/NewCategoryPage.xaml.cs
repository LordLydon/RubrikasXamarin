using System;
using RubrikasMasterDetail.Models;
using RubrikasMasterDetail.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RubrikasMasterDetail.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewCategoryPage : ConnectedContentPage
	{
		private NewCategoryViewModel viewModel { get; set; }
		private bool isEditing = false;

        public NewCategoryPage(bool connected = true) : base(connected)
		{
			InitializeComponent ();

			BindingContext = viewModel = new NewCategoryViewModel();
		}

		public NewCategoryPage(NewCategoryViewModel viewModel, bool connected = true) : base(connected)
		{
			InitializeComponent();

			BindingContext = this.viewModel = viewModel;
			isEditing = true;
		}

		private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			if (!(args.SelectedItem is Criterion item))
				return;

			await Navigation.PushAsync(new NewCriterionPage(viewModel.Item ,new NewCriterionViewModel(item)));

			// Manually deselect item
			ItemsListView.SelectedItem = null;
		}

		private async void AddItem_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewCriterionPage(viewModel.Item));
		}

		async void Save_Clicked(object sender, EventArgs e)
		{
			if (IsConnected)
			{
				if (Category.IsValid(viewModel.Item))
				{
					MessagingCenter.Send(this, isEditing ? "UpdateItem" : "AddItem", viewModel.Item);
					await Navigation.PopAsync();
				}
				else
				{
					await DisplayAlert("Error", "Todos los campos son requeridos y la suma de los pesos de los elementos debe ser 100%!", "OK");
				}
			}
			else
			{
				DisplayNotConnectedError();
			}
		}

		protected override void SwitchConnectedFeatures(){}
	}
}