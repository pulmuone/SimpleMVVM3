using SimpleMVVM.Controls;
using SimpleMVVM.Models;
using SimpleMVVM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleMVVM.ViewModels
{
    public class InboundViewModel : ViewModelBase
    {
        private ObservableRangeCollection<InboundModel> _inboundList = new ObservableRangeCollection<InboundModel>();
        private DateTime _inboundDate = Convert.ToDateTime("1900-01-01");
        private string _invoiceNumber;
        private InboundModel _selectedItem 
            = new InboundModel();
        
        private List<InboundModel> _selectedItems 
            = new List<InboundModel>();
        
        public ICommand SearchCommand { get; private set; }


        public InboundViewModel()
        {

            SearchCommand = new Command(Search);

            List<InboundModel> lst = new List<InboundModel>
            {
                new InboundModel{ InvoiceNumber ="ABC1234", InboundDate ="2019-10-11",  VenderCode="Z101", VenderName="매입업체 Z101", Remark ="긴급 주문입니다." },
                new InboundModel{ InvoiceNumber ="ABC1235", InboundDate ="2019-10-11",  VenderCode="Z102", VenderName="매입업체 Z102", Remark ="영업팀 확인 요망"  },
                new InboundModel{ InvoiceNumber ="ABC1236", InboundDate ="2019-10-11",  VenderCode="Z103", VenderName="매입업체 Z103", Remark = string.Empty }
            };

            InboundList.Clear();
            InboundList.AddRange(lst, System.Collections.Specialized.NotifyCollectionChangedAction.Reset);

            InboundDate = DateTime.Now;        }

        private async void Search(object obj)
        {
            Console.WriteLine("Search");

            // Console.WriteLine(SelectedItem.InvoiceNumber);
            foreach (var item in SelectedItems)
            {
                Console.WriteLine(item.InvoiceNumber);
            }

            InboundItemsViewModel vm = new InboundItemsViewModel();

            await Application.Current.MainPage.Navigation.PushAsync(new InboundItemsView());
        }

        public ObservableRangeCollection<InboundModel> InboundList
        {
            get => _inboundList;
            set => SetProperty(ref this._inboundList, value);
        }

        public List<InboundModel> SelectedItems 
        { 
            get => _selectedItems; 
            set => SetProperty(ref _selectedItems, value);
        }
        public InboundModel SelectedItem 
        { 
            get => _selectedItem; 
            set => SetProperty(ref _selectedItem, value); 
        }
        public DateTime InboundDate { get => _inboundDate; set => SetProperty(ref _inboundDate, value); }
        public string InvoiceNumber { get => _invoiceNumber; set => SetProperty(ref _invoiceNumber, value); }

    }
}
