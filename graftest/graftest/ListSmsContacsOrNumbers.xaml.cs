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
	public partial class ListSmsContacsOrNumbers : ContentPage
	{
        List<string[]> listSMS = new List<string[]>();
        string PNumber;
		public ListSmsContacsOrNumbers (string pnimber)
		{
			InitializeComponent ();
            PNumber = pnimber;
            get();

        }
        void get()
        {
            listSMS = DependencyService.Get<Interface>().Dslc();
            List<string> bufList = new List<string>();
            foreach(var buf in listSMS)
            {
                if (listCheck(bufList, buf[0]))

                    bufList.Add(buf[0]);

            }
            Listv.ItemsSource = bufList;

        }

        private async void SLelectItem(object sender, EventArgs e)
        {
            string bufs = Listv.SelectedItem.ToString();
            await Navigation.PushAsync(new ListSms(listSMS,bufs, PNumber));
        }


        bool listCheck(List<string> bufList, string itemString)
        {
            foreach (var buString in bufList)
            {
                if (buString == itemString)
                    return false;
            }
            return true;
        }
    }
}