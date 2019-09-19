using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XsenoCode;
namespace graftest
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReadSelectedEmail : ContentPage
	{
        private string login;
        private string bufs;
		public ReadSelectedEmail (string Email,string Header,string TextBody, string Login)
		{
			InitializeComponent ();
            Adresslb.Text = Email;
            Headerlb.Text = Header;
            login = Login;
            Textlb.Text =bufs= TextBody;
		}

        private void IsTg(object sender, EventArgs e)
        {
            if(IsEnc.IsToggled)
            {
                try
                {
                    XenoCode a = new XenoCode();
                    Textlb.Text = a.decryption(Textlb.Text, login, Adresslb.Text);
                }
                catch

                {
                    IsEnc.IsToggled = false;
                }
            }
            else
            {
                Textlb.Text = bufs;
            }
        }

    }
}