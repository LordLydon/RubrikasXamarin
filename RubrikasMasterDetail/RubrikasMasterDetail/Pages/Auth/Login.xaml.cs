using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RubrikasMasterDetail
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ConnectedContentPage
	{
		public Login (bool connected = true) : base(connected)
		{
			InitializeComponent ();
		}

		private async void OnSignUpButtonClicked(object sender, EventArgs e)
		{
			if (!IsConnected)
			{
                DisplayNotConnectedError();

			}
			else
			{
				
			}
		}

		private async void OnLoginButtonClicked(object sender, EventArgs e)
		{
			if (!IsConnected)
			{
				DisplayNotConnectedError();

			}
			else
			{

			}
		}
	}
}