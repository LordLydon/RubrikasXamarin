using Xamarin.Forms;

namespace RubrikasMasterDetail.Pages
{
    public abstract class ConnectedContentPage : ContentPage
    {
        protected bool IsConnected { get; private set; }

        protected ConnectedContentPage(bool connected = true)
        {
            IsConnected = connected;
            MessagingCenter.Subscribe<App, bool>(this, "ConnectivityChanged", HandleConnectivityChanged);
            if (!IsConnected) DisplayNotConnectedError();
        }

        private void HandleConnectivityChanged(App app, bool connected)
        {
            if (IsConnected == connected) return;
            
            IsConnected = connected;
            SwitchConnectedFeatures();

            if (!IsConnected)
                DisplayNotConnectedError();
        }

        protected async void DisplayNotConnectedError()
        {
            await DisplayAlert("Error!", "No tienes conexión a internet.\nVuelve a conectarte e intenta de nuevo","Ok");
        }

        protected abstract void SwitchConnectedFeatures();
    }
}
