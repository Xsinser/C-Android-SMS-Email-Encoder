using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace graftest
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewMenuPage : ContentPage
	{
        private string pnumber;
		public NewMenuPage (string PNumber)
		{
			InitializeComponent ();
            pnumber = PNumber;
		}
        private async void EmailPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmailPage());
        }
        private async void SmsSend(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SendSms(pnumber));
        }

        private async void SmsGet(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListSmsContacsOrNumbers(pnumber));
        }
    }
}