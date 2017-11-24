using System;
using RubrikasMasterDetail.Models;
using RubrikasMasterDetail.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RubrikasMasterDetail.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewCriterionPage : ConnectedContentPage
	{
		private NewCriterionViewModel viewModel { get; set; }
		private Category category;
		private bool isEditing = false;
		
        public NewCriterionPage(Category category, bool connected = true) : base(connected)
		{
			InitializeComponent ();
			
			this.category = category;
			BindingContext = viewModel = new NewCriterionViewModel();
		}

		public NewCriterionPage(Category category, NewCriterionViewModel viewModel, bool connected = true) : base(connected)
		{
			InitializeComponent();

			this.category = category;
			BindingContext = this.viewModel = viewModel;
			isEditing = true;
		}

		async void Save_Clicked(object sender, EventArgs e)
		{
			if (IsConnected)
			{
				if (Criterion.IsValid(viewModel.Item))
				{
					MessagingCenter.Send(this, isEditing ? "UpdateItem" : "AddItem",
						new CriterionResult {Category = category, Criterion = viewModel.Item});
					await Navigation.PopAsync();
				}
				else
				{
					await DisplayAlert("Error", "Todos los campos son requeridos!\nY no olvides que las calificaciones son de 0 a 5.", "OK");
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