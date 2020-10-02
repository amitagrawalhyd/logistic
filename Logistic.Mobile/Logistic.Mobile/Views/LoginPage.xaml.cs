using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Logistic.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BtnLoginUsingFp.Clicked += BtnLoginUsingFpClicked;
        }

        private async void BtnLoginUsingFpClicked(object sender, EventArgs e)
        {
            //Check if Finger Print Available
            var isFingerPrintAvailable = await CrossFingerprint.Current.IsAvailableAsync(true);
            if (isFingerPrintAvailable)
            {
                var authenticate = await CrossFingerprint.Current.AuthenticateAsync(new AuthenticationRequestConfiguration("Logistics", "Authenticate access to Logistics"));
                if(authenticate.Authenticated)
                    await DisplayAlert("Logistics", "Authenticated", "OK");
                else
                {
                    await DisplayAlert("Logistics", "Not Authenticated", "OK");
                }
            }
            else
            {
                await DisplayAlert("Logistics", "Device is not equipped with Finger Print Scanner", "OK");
            }
        }

        private void LoginPage_OnSizeChanged(object sender, EventArgs e)
        {
            if (Width * Height < 0)
            {
                return;
            }

            if (Width > Height)
            {
                MainGrid.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);
                MainGrid.RowDefinitions[1].Height = 0;

                Grid.SetColumn(LoginStackLayout, 1);
                Grid.SetRow(LoginStackLayout, 0);
            }
            else
            {
                MainGrid.ColumnDefinitions[1].Width = 0;
                MainGrid.RowDefinitions[1].Height = new GridLength(1, GridUnitType.Star);

                Grid.SetColumn(LoginStackLayout, 0);
                Grid.SetRow(LoginStackLayout, 1);
            }
        }
    }
}