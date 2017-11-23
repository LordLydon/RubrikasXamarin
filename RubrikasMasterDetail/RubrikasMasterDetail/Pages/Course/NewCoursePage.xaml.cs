using System;
using RubrikasMasterDetail.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RubrikasMasterDetail.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewCoursePage : ConnectedContentPage
	{
		private Course Item { get; set; }

        public NewCoursePage (bool connected = true) : base(connected)
		{
			InitializeComponent ();

			BindingContext = Item = new Course();
		}

		async void Save_Clicked(object sender, EventArgs e)
		{
			if (IsConnected)
			{
				if (Course.IsValid(Item))
				{
					MessagingCenter.Send(this, "AddItem", Item);
					await Navigation.PopToRootAsync();
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

		protected override void SwitchConnectedFeatures(){}
	}
}