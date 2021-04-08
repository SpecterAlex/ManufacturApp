using System;
using ColmenApp.Interfaces;
using ColmenApp.Services;
using ColmenApp.ViewModels;
using ColmenApp.Views;
using Xamarin.Forms;

namespace ColmenApp
{
    public partial class App : Application
    {
        //TOKEN
        public static string Token { get; set; }
        public App()
        {
            InitializeComponent();
            
            //MainPage = new NavigationPage(new LoginView());
            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            navigationService.InitializeAsync();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
