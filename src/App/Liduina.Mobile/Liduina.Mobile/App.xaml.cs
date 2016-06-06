﻿using Liduina.Mobile.DeviceServices;
using Liduina.Mobile.I18n;
using Liduina.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Liduina.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            // The root page of your application
            InitializeComponent();
            MainPage = new NavigationPage(new MainPageView());

            if (Device.OS != TargetPlatform.WinPhone && Device.OS != TargetPlatform.Windows)
            {
                AppResources.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
