using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
	public partial class EvaluationsPage : ConnectedContentPage
	{

		private Course course;
		private EvaluationsViewModel viewModel;
		
		public EvaluationsPage(Course course, bool connected = true) : base(connected)
		{
			BindingContext = viewModel = new EvaluationsViewModel(course);
			this.course = course;
			InitializeComponent();
			SwitchConnectedFeatures();
		}

		private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			if (!(args.SelectedItem is Models.Evaluation item))
				return;

			await Navigation.PushAsync(new EvaluationDetailPage(new EvaluationDetailViewModel(course, item), IsConnected));
			
			// Manually deselect item
			ItemsListView.SelectedItem = null;
		}

		private async void AddItem_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewEvaluationPage());
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (viewModel.Items.Count == 0 && IsConnected)
				viewModel.LoadItemsCommand.Execute(null);
		}

		protected sealed override void SwitchConnectedFeatures()
		{
			ItemsListView.IsPullToRefreshEnabled = IsConnected;
		}
	}
}