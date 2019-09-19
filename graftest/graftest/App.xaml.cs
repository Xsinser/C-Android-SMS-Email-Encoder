using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace graftest
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            var page = new NavigationPage(new MainPage());
            page.BarBackgroundColor = Color.FromHex("#FF4C079E");
            MainPage = page;
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
