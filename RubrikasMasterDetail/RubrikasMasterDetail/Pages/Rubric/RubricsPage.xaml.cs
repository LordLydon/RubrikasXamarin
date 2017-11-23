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
	public partial class RubricsPage : ConnectedContentPage
	{
		RubricsViewModel viewModel;

		public RubricsPage(bool connected = true) : base(connected)
		{
			InitializeComponent();
			BindingContext = viewModel = new RubricsViewModel();
			SwitchConnectedFeatures();
		}

		public RubricsPage()
		{
			InitializeComponent();
			BindingContext = viewModel = new RubricsViewModel();
			SwitchConnectedFeatures();
		}

		private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			if (!(args.SelectedItem is Rubric item))
				return;

			await Navigation.PushAsync(new RubricDetailPage(new RubricDetailViewModel(item)));

			// Manually deselect item
			ItemsListView.SelectedItem = null;
		}

		private async void AddItem_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewRubricPage());
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