﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RubrikasMasterDetail.Models;
using RubrikasMasterDetail.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RubrikasMasterDetail
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CoursesPage : ConnectedContentPage
	{
		CoursesViewModel viewModel;
		
        public CoursesPage ()
		{
			InitializeComponent ();


			BindingContext = viewModel = new CoursesViewModel();
        }

		async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			if (!(args.SelectedItem is Course item))
				return;

			await Navigation.PushAsync(new CourseDetailPage(new CourseDetailViewModel(item)));

			// Manually deselect item
			ItemsListView.SelectedItem = null;
		}

		async void AddItem_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewCoursePage());
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (viewModel.Items.Count == 0)
				viewModel.LoadItemsCommand.Execute(null);
		}
	}
}