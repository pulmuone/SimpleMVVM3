using SimpleMVVM.ViewModels;
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
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();

            //ImagPallet.Source = new UriImageSource
            //{ 
            //    Uri = new Uri("https://xamarin.com/content/images/pages/forms/example-app.png"),
            //    CachingEnabled = true,
            //    CacheValidity = new TimeSpan(5, 0, 0, 0)
            //};
        }
    }
}