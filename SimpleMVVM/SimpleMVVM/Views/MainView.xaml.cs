using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void OutboundButton_Clicked(object sender, EventArgs e)
        {

        }

        private async void InboundButton_Clicked(object sender, EventArgs e)
        {
            foreach (var item in Navigation.NavigationStack)
            {
                //중복 클릭 방지
                if (item.ToString().EndsWith("InboundView"))
                {
                    return;
                }
            }

            await Navigation.PushAsync(new InboundView());
        }

        private async void LogoutButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
            Application.Current.MainPage = new NavigationPage(new Views.LoginView());
        }
    }
}