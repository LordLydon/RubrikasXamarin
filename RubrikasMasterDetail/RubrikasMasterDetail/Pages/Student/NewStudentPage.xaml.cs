using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RubrikasMasterDetail.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RubrikasMasterDetail.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewStudentPage : ConnectedContentPage
	{
		private Student Item { get; set; }

		public NewStudentPage(bool connected = true) : base(connected)
		{
			InitializeComponent();

			BindingContext = Item = new Student();
		}

		async void Save_Clicked(object sender, EventArgs e)
		{
			if (IsConnected)
			{
				if (Student.IsValid(Item))
				{
					MessagingCenter.Send(this, "AddItem", Item);
					await Navigation.PopAsync();
				}
				else
				{
					await DisplayAlert("Error", "Todas los campos son requeridas!", "OK");
				}
			}
			else
			{
				DisplayNotConnectedError();
			}
		}

		protected override void SwitchConnectedFeatures()
		{
		}

		
	}
}