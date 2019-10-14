using SimpleMVVM.Models;
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
    public partial class InboundView : ContentPage
    {
        public InboundView()
        {
            InitializeComponent();
        }

        private async void listItem_Tapped(object sender, EventArgs e)
        {
            InboundModel selectedItem = (InboundModel)(BindingContext as InboundViewModel).InboundList.Where(i => i.InvoiceNumber == ((TappedEventArgs)e).Parameter).FirstOrDefault();
            this.collectionView.SelectedItem = selectedItem;

            foreach (var item in Navigation.NavigationStack)
            {
                //Console.WriteLine("Title => " + item.BindingContext);

                //중복 클릭 방지
                if (item.BindingContext !=null && item.BindingContext.ToString().EndsWith("InboundItemsViewModel"))
                {
                    return;
                }
            }

            //await Navigation.PushAsync(new InboundItemsView(selectedItem));
            //await Navigation.PushAsync(new InboundItemsView());
        }

        private void VenderNameEntry_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void VenderNameEntry_Unfocused(object sender, FocusEventArgs e)
        {

        }

        private void VenderNameEntry_Focused(object sender, FocusEventArgs e)
        {
            InboundModel selectedItem = (InboundModel)(BindingContext as InboundViewModel).InboundList.Where(i => i.InvoiceNumber == ((Entry)sender).ReturnCommandParameter).FirstOrDefault();
            //this.collectionView.SelectedItem = selectedItem;

            collectionView.SelectedItems.Add(selectedItem);
        }
    }
}