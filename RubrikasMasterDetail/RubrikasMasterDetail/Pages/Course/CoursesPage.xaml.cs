﻿using System;
using RubrikasMasterDetail.Models;
using RubrikasMasterDetail.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RubrikasMasterDetail.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CoursesPage : ConnectedContentPage
	{
		CoursesViewModel viewModel;
		
        public CoursesPage (bool connected = true) : base(connected)
        {
			InitializeComponent ();
			BindingContext = viewModel = new CoursesViewModel();
			SwitchConnectedFeatures();
        }

		public CoursesPage()
		{
			InitializeComponent();
			BindingContext = viewModel = new CoursesViewModel();
			SwitchConnectedFeatures();
		}

		private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			if (!(args.SelectedItem is Course item))
				return;

			await Navigation.PushAsync(new CourseDetailPage(new CourseDetailViewModel(item), IsConnected));

			// Manually deselect item
			ItemsListView.SelectedItem = null;
		}

		private async void AddItem_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewCoursePage(IsConnected));
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