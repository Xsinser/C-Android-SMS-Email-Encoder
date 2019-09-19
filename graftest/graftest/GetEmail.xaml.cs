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
	public partial class GetEmail : ContentPage
	{
        private string login, pass;


        List<string[]> listEmails = new List<string[]>();


		public GetEmail (string Login,string Pass)
		{
			InitializeComponent ();
            login = Login;
            pass = Pass;

            addList();


        }

        private async void SLelectItem(object sender,EventArgs e)
        {
            string bufs = Listv.SelectedItem.ToString();
            await Navigation.PushAsync(new ListEmails(listEmails,bufs,login));
        }

        async void  addList()
        {
            loading.IsVisible = true;
            await Task.Run(async () =>
            {
                get();
            });
            ///////////////////////////////////////
            List<string> bufList = new List<string>();
                foreach (var bufS in listEmails)
                {
                    if (listCheck(bufList, bufS[1]))
                        bufList.Add(bufS[1]);
                }
            loading.IsVisible = false;
            Listv.ItemsSource = bufList;
        }

        bool listCheck(List<string> bufList, string itemString)
        {
            foreach(var buString in bufList)
            {
                if (buString == itemString)
                    return false;
            }
            return true;
        }

        void get()
        {
            
            using (var client = new Pop3Client())
            {

                try{
                    string[] words = login.Split(new char[] { '@' });
                    string pop3 = "pop." + words[1];
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect(pop3, 995, true);

                    client.Authenticate(login, pass);


                    int z = client.Count;
                    for (int i = 0; i < client.Count; i++)
                    {
                        string[] bufMassS = new string[3];
                        var message = client.GetMessage(i);

                        int starti = message.From.ToString().IndexOf(" <");
                        string bufs = message.From.ToString();
                        bufs = bufs.Remove(0, starti + 1);
                        bufs = bufs.Replace("<", "");
                        bufs = bufs.Replace(">", "");
                        //обрезка
                        bufMassS[1] = bufs;
                        bufMassS[0] = checkSubject(message.Subject.ToString(), 1, message.Subject.ToString());//тема
                        bufMassS[2] = message.TextBody;



                        listEmails.Add(bufMassS);
                    }

                    client.Disconnect(true);
                }
                catch
                {

                }
            }
            listEmails.Reverse();
           
        }
        //добавление  (id) если уже есть такая тема, на всякий случай
        string checkSubject(string strChek,int id,string control)
        {
            string bufferString= strChek;
            foreach(var bufs in listEmails)
            {
                if(bufs[0]==strChek)
                {
                   
                    {
                        bufferString = control+"(" + id + ")";
                        id++;
                        bufferString = checkSubject(bufferString, id, control);
                    }

                }
            }
            return bufferString;
        }
    }
}