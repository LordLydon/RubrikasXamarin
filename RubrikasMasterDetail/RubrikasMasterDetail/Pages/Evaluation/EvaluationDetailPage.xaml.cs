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
	public partial class EvaluationDetailPage : ConnectedContentPage
	{
		private EvaluationDetailViewModel viewModel;

		public EvaluationDetailPage(EvaluationDetailViewModel item, bool connected = true) : base(connected)
		{
			InitializeComponent ();
			BindingContext = viewModel = item;
		}

		private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			if (!(args.SelectedItem is GradedStudent item))
				return;

			await Navigation.PushAsync(new GradeEvaluation(new GradeEvaluationViewModel(viewModel.Course, viewModel.Item, item),
				IsConnected));

			// Manually deselect item
			ItemsListView.SelectedItem = null;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (viewModel.Items.Count == 0 && IsConnected)
				viewModel.LoadItemsCommand.Execute(null);
		}

		protected override void SwitchConnectedFeatures()
		{
			ItemsListView.IsPullToRefreshEnabled = IsConnected;
		}
	}
}