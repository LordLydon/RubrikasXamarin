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
	public partial class NewEvaluationPage : ConnectedContentPage
	{
		private NewEvaluationViewModel viewModel;
		
		public NewEvaluationPage(bool connected = true) : base(connected)
		{
			InitializeComponent();

			BindingContext = viewModel = new NewEvaluationViewModel();
			viewModel.LoadItemsCommand.Execute(null);
		}

		async void Save_Clicked(object sender, EventArgs e)
		{
			if (IsConnected)
			{
				if (RubricPicker.SelectedItem is Rubric rubric)
				{
					viewModel.Item.RubricId = rubric.Key;
					if (Evaluation.IsValid(viewModel.Item))
					{
						MessagingCenter.Send(this, "AddItem", viewModel.Item);
						await Navigation.PopAsync();
					}
					else
					{
						await DisplayAlert("Error", "Todos los campos son requeridos!", "OK");
					}
				}
				else
				{
					await DisplayAlert("Error!", "Tienes que escoger una rubrica para continuar", "OK");
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