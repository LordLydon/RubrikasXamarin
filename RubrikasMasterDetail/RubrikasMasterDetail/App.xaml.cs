using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Xamarin.Forms;

namespace RubrikasMasterDetail
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			//Verificar Conexión
			CrossConnectivity.Current.ConnectivityChanged += HandleConnectivityChanged;

			//MainPage = !Current.Properties.ContainsKey("auth") ? new NavigationPage(new Login()) : new NavigationPage(new MainPage());
			MainPage = new NavigationPage(new Menu());
		}

		void HandleConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
		{
			MessagingCenter.Send(this, "ConnectivityChanged", e.IsConnected);
		}
	

	protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
