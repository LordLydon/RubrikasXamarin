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
	public partial class StudentsPage : ConnectedContentPage
	{
		private Course course;
		private StudentsViewModel viewModel;

		public StudentsPage ()
		{
			InitializeComponent ();
		}

		public StudentsPage(Course course, bool connected = true)
		{
			InitializeComponent();
			BindingContext = viewModel = new StudentsViewModel(course);
			this.course = course;
			SwitchConnectedFeatures();
		}

		private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			if (!(args.SelectedItem is Student item))
				return;

			await Navigation.PushAsync(new StudentDetailPage(new StudentDetailViewModel(item)));

			// Manually deselect item
			ItemsListView.SelectedItem = null;
		}

		private async void AddItem_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewStudentPage());
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