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
	public partial class ReadSms : ContentPage
	{
        private string textSms, phone;
        string PNumber;
		public ReadSms (string TextSms,string Phone,string pnumber)
		{
            textSms = TextSms;

            phone = Phone;

			InitializeComponent ();

            Adresslb.Text = Phone;

            PNumber = pnumber;

            Textlb.Text = textSms;

        }

        private void Chng(object sender,EventArgs e)
        {
            if (IsEnc.IsToggled)
            {
                XenoCode a = new XenoCode();
               
             string[]   words = Textlb.Text.Split(new char[] { ' ' });
                string h = words[1];
                for (int o = 3; o < h.Length; o = o + 4)
                {
                    h = h.Insert(o, " ");
                }
          string      bufs = words[0] + " " + h;
                /////////////////////////
                string bufAdr=SupportClass.NumberCorrect( Adresslb.Text);
                try
                {
                    Textlb.Text = a.decryption(bufs + " &", PNumber, bufAdr);
                }
                catch
                {
                    IsEnc.IsToggled = false;
                }
            }
            else
            {
                Textlb.Text = textSms;
            }
        }

    }
}