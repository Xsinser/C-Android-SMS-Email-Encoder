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
	public partial class SmsPage : ContentPage
	{
		public SmsPage ()
		{
			InitializeComponent ();
		}

        private async void SmsSend(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SendSms(SupportClass.NumberCorrect( PNumber.Text)));
        }

        private async void SmsGet(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListSmsContacsOrNumbers(SupportClass.NumberCorrect(PNumber.Text)));
        }

        void CheckNumber()
        {

        }
    }

}