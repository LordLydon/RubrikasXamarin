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
	public partial class GradeEvaluation : ConnectedContentPage
	{
		private GradeEvaluationViewModel viewModel;
		
		public GradeEvaluation(GradeEvaluationViewModel item, bool connected = true) : base(connected)
		{
			InitializeComponent();
			BindingContext = viewModel = item;
		}

		async void Save_Clicked(object sender, EventArgs e)
		{
			if (IsConnected)
			{
				if (Models.Grade.IsValid(viewModel.GradedStudent.Grade))
				{
					MessagingCenter.Send(this, "AddItem", viewModel.GradedStudent.Grade);
					await Navigation.PopAsync();
				}
				else
				{
					await DisplayAlert("Error", "Todos los campos son requeridos!", "OK");
				}
			}
			else
			{
				DisplayNotConnectedError();
			}
		}

		private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			if (!(args.SelectedItem is GradedCategory item))
				return;

			await Navigation.PushAsync(new GradeCategory(new GradeCategoryViewModel(viewModel.Course, viewModel.Evaluation, viewModel.GradedStudent, item),
				IsConnected));

			// Manually deselect item
			ItemsListView.SelectedItem = null;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (viewModel.Items.Count == 0 && IsConnected)
				viewModel.LoadItemsCommand.Execute(null);
			
			viewModel.UpdateTotal();
		}

		protected override void SwitchConnectedFeatures()
		{
			ItemsListView.IsPullToRefreshEnabled = IsConnected;
		}
	}
}