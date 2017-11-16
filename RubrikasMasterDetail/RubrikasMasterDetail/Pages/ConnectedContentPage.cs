using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RubrikasMasterDetail
{
    public class ConnectedContentPage : ContentPage
    {
        protected bool IsConnected { get; private set; }

        protected ConnectedContentPage(bool connected = true)
        {
            IsConnected = connected;
            MessagingCenter.Subscribe<App, bool>(this, "ConnectivityChanged", HandleConnectivityChanged);
        }

        private void HandleConnectivityChanged(App app, bool connected)
        {
            if (!connected)
                DisplayNotConnectedError();

            IsConnected = connected;
        }

        protected async void DisplayNotConnectedError()
        {
            await DisplayAlert("Error!", "No tienes conexión a internet.\nVuelve a conectarte e intenta de nuevo","Ok");
        }
    }
}
