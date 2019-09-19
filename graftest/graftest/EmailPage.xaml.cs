using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MailKit.Net.Pop3;
using MailKit;
using MimeKit;

namespace graftest
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmailPage : ContentPage
	{
		public EmailPage ()
		{
			InitializeComponent ();
		}
        bool CheckEmail()
        {
            try
            {
                using (var client = new Pop3Client())
                {
                    // поправить

                    string[] words = EmailE.Text.Split(new char[] { '@' });
                    string pop3 = "pop." + words[1];
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect(pop3, 995, true);

                    client.Authenticate(EmailE.Text, PassE.Text);

                }
            }
            catch
            {
                DisplayAlert("Ошибка", "Введен неправильный Email или пароль!", "ОK");
                return false;
            }
                return true;
        }
        private async void sendPage(object sender, EventArgs e)
        {
            if(CheckEmail())
            await Navigation.PushAsync(new SendPage(EmailE.Text,PassE.Text));
        }
        
        private async void getPage(object sender, EventArgs e)
        {
            if (CheckEmail())
                await Navigation.PushAsync(new GetEmail(EmailE.Text, PassE.Text));
        }
    }
}