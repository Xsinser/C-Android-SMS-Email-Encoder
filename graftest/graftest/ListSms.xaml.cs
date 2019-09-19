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
	public partial class ListSms : ContentPage
	{
        List<string[]> listSms = new List<string[]>();
        private string selestedPhone;
        string PNumber;
		public ListSms (List<string[]> bufList, string selectedphone,string pnumber)
		{
            

			InitializeComponent ();
            listSms = bufList;
            selestedPhone = selectedphone;
            PNumber = pnumber;
            get();
        }
        private async void SLelectItem(object sender, EventArgs e)
        {
            string bufs = Listv.SelectedItem.ToString();
            await Navigation.PushAsync(new ReadSms(bufs,selestedPhone, PNumber));
        }
        void get()
        {
            List<string> bufLsit = new List<string>();
            foreach(var bufs in listSms)
            {
                if(bufs[0]==selestedPhone)
                {
                    bufLsit.Add(bufs[1]);
                }
            }
            Listv.ItemsSource = bufLsit;
        }
	}
}