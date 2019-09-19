using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using XsenoCode;
namespace graftest
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SendPage : ContentPage
	{
        private string login, pass;
		public SendPage (string Login, string Pass)
		{
			InitializeComponent ();
            login = Login;
            pass = Pass;
		}
        private void SendClik(object sender,EventArgs e)
        {
           sendEmail();
        }
        string sendEmail()
        {
            try
            {

                MailMessage mail = new MailMessage();

                string[] words = login.Split(new char[] { '@' });
                string smtp = "smtp." + words[1];
                SmtpClient SmtpServer = new SmtpClient(smtp);
                mail.From = new MailAddress(login);
                mail.To.Add(AdressEmail.Text);
                mail.Subject = HeaderEmail.Text;

                XenoCode a = new XenoCode();
                if (IsEnc.IsToggled)
                    mail.Body = a.RSA_encryption(BodyEmail.Text, login, AdressEmail.Text) + "&";
                else
                    mail.Body = BodyEmail.Text;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(login, pass);
                SmtpServer.EnableSsl = true;
                ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
                SmtpServer.Send(mail);
                BodyEmail.Text = AdressEmail.Text = HeaderEmail.Text = "";
                return "good";
            }
            catch (Exception ei)
            {
                DisplayAlert("Ошибка", "Не отправлено!", "ОK");
                return ei.ToString();
            }
        }

    }
}