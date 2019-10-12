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
    public partial class Login2View : ContentPage
    {
        public Login2View()
        {
            InitializeComponent();
        }

        private void PasswdEntry_Completed(object sender, EventArgs e)
        {
            Console.WriteLine( this.PasswdEntry.Text);
            Console.WriteLine((sender as Entry).Text);


        }
    }
}