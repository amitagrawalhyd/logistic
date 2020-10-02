using System;
using Logistic.Mobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;


namespace Logistic.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=bfbbf554-586c-4770-855b-030e5fbe3c4d;",
                typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
