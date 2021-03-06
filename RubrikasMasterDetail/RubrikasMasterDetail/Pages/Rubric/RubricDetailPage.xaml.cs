﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RubrikasMasterDetail.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RubrikasMasterDetail.Models;

namespace RubrikasMasterDetail.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RubricDetailPage : ContentPage
	{
		private RubricDetailViewModel viewModel;

		public RubricDetailPage(RubricDetailViewModel item)
		{
			InitializeComponent();
			BindingContext = viewModel = item;
		}

		private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			if (!(args.SelectedItem is Category item))
				return;

			await Navigation.PushAsync(new CategoryDetailPage(new CategoryDetailViewModel(item)));

			// Manually deselect item
			ItemsListView.SelectedItem = null;
		}
	}
}