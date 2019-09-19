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
	public partial class ListEmails : ContentPage
	{
        List<string[]> listEmails = new List<string[]>();
        private string selectedEmail;
        List<string> DefencList = new List<string>();
        private string login;

		public ListEmails (List<string[]> ListEmails, string SelectedEmail,string Login)
		{
			InitializeComponent();
            listEmails = ListEmails;
            selectedEmail = SelectedEmail;
            login = Login;
            listAdd();

        }
        void listAdd()
        {
            List<string> bufList = new List<string>();

            foreach(var bufs in listEmails)
            {
                if (bufs[1] == selectedEmail)
                {
                    bufList.Add(bufs[0]);
                    DefencList.Add(bufs[2]);
                }
            }
            Listv.ItemsSource = bufList;
        }

        string search(string selectedHeader)
        { 
            foreach(var bufs in listEmails)
            {
                if ((bufs[0] == selectedHeader) && (bufs[1] == selectedEmail))
                    return bufs[2];
            }
            return "";
        }
        private async void SLelectItem(object sender, EventArgs e)
        {
            string bufs = Listv.SelectedItem.ToString();
           
            await Navigation.PushAsync(new ReadSelectedEmail(selectedEmail,bufs, search(bufs),login));
        }
    }
}