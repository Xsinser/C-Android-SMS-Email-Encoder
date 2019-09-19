using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XsenoCodeSms;
namespace graftest
{
	[XamlCompilation(XamlCompilationOptions.Compile)]

	public partial class SendSms : ContentPage
	{
        string PNumber = "";

        bool checkNullString()
        {
            if((AdressEmail.Text!="")&&(BodyEmail.Text!=""))
                    return true;
            else
            return false;
        }

        public SendSms (string number)
		{
			InitializeComponent ();
            PNumber = number;
		}
        private void SendClik(object sender,EventArgs e)
        {
            if (checkNullString())
            {
                try
                {
                    string bufNumber = SupportClass.NumberCorrect(AdressEmail.Text);
                    if (IsEnc.IsToggled)
                    {
                        string bufs = "";

                        XenoCode a = new XenoCode();

                        bufs = a.RSA_encryption(BodyEmail.Text, PNumber, bufNumber);

                        ////////////////////////////////////////
                        string[] words = bufs.Split(new char[] { ' ' });
                        string header = words[0] + " ";
                        bufs = bufs.Replace(words[0], " ");
                        bufs = bufs.Replace(" ", "");
                        bufs = header + bufs;
                        DependencyService.Get<Interface>().Send(bufNumber, bufs);
                    }
                    else
                        DependencyService.Get<Interface>().Send(bufNumber, BodyEmail.Text);

                    BodyEmail.Text = AdressEmail.Text = "";
                }
                catch
                {
                    DisplayAlert("Ошибка", "Не отправлено!", "ОK");
                }
            }
        }

        private void TxtCn(object sender,EventArgs e)
        {
            CountChr.Text = BodyEmail.Text.Length + " из 50"; 
        }
    }
}