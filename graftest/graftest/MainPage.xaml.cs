using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace graftest
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
           
           
        }

        private async void ToMenu(object sender, EventArgs e)
        {
            if(PNumber.Text.Length>0)
                   if(SupportClass.NumberCorrect(PNumber.Text).Length==11)
            await Navigation.PushAsync(new NewMenuPage(SupportClass.NumberCorrect(PNumber.Text)));
            else
                    DisplayAlert("Ошибка", "Не корректный номер телефона", "ОK");
        }

    }
}
