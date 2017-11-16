using System;
using RubrikasMasterDetail.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RubrikasMasterDetail.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewCoursePage : ConnectedContentPage
	{
		public Course Item { get; set; }

        public NewCoursePage ()
		{
			InitializeComponent ();

			Item = new Course
			{
				Name = "Nombre del curso",
				NRC = "NRC del curso."
			};

			BindingContext = this;
		}

		async void Save_Clicked(object sender, EventArgs e)
		{
			if (IsConnected)
			{
				MessagingCenter.Send(this, "AddItem", Item);
				await Navigation.PopToRootAsync();
			}
			else
			{
				DisplayNotConnectedError();
			}
		}
    }
}