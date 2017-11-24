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
	public partial class GradeCategory : ConnectedContentPage
	{
		private GradeCategoryViewModel viewModel;

		public GradeCategory(GradeCategoryViewModel item, bool connected = true) : base(connected)
		{
			InitializeComponent();
			BindingContext = viewModel = item;
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

		private void LevelPicker_OnSelectedIndexChanged(object sender, EventArgs e)
		{
			viewModel.UpdateTotal();
		}
	}
}