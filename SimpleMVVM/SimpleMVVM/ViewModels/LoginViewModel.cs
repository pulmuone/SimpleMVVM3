using SimpleMVVM.Controls;
using SimpleMVVM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;

namespace SimpleMVVM.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        private int ClickCount = 0;

        private bool isControlEnable = true;
        private string _userid = string.Empty;
        private string _password = string.Empty;
        private ObservableRangeCollection<WarehouseModel> _warehouseList = new ObservableRangeCollection<WarehouseModel>();

        public ICommand LoginCommand { get; private set; }

        public LoginViewModel()
        {
            List<WarehouseModel> lst = new List<WarehouseModel> 
            { 
                new WarehouseModel{ WarheouseCode="1001",  WarehouseName="용인 물류센터"},
                new WarehouseModel{ WarheouseCode="1002",  WarehouseName="수지 물류센터"},
                new WarehouseModel{ WarheouseCode="1003",  WarehouseName="천안 물류센터"},
                new WarehouseModel{ WarheouseCode="1004",  WarehouseName="부산 물류센터"}
            };

            WarehouseList.AddRange(lst);

            LoginCommand = new Command(async()=>await Login(), ()=> IsControlEnable);
            //LoginCommand = new Command(async () => await Login());


        }

        private async Task Login()
        {
            bool result;
            IsBusy = true;
            IsControlEnable = false;
            (LoginCommand as Command).ChangeCanExecute();

            Console.WriteLine("Clicked Count : {0}", ClickCount++);
            Console.WriteLine("Login Process : {0}, {1}", UserID, Password);

            result = await Task.Run(() => LoginProcess());

            if(result)
            {
                Application.Current.MainPage.Navigation.InsertPageBefore(new Views.MainView(), Application.Current.MainPage.Navigation.NavigationStack.Last());
                await Application.Current.MainPage.Navigation.PopAsync();
            }

            IsControlEnable = true;
            (LoginCommand as Command).ChangeCanExecute();
            IsBusy = false;
        }


        private bool LoginProcess()
        {
            // Simulate a 5 second pause
            Thread.Sleep(1000);
            //db연결

            return true;

            //var endTime = DateTime.Now.AddSeconds(5);
            //while (true)
            //{
            //    if (DateTime.Now >= endTime)
            //    {
            //        break;
            //    }
            //}
        }

        public bool IsControlEnable
        {
            get => isControlEnable;
            set => SetProperty(ref this.isControlEnable, value);
        }

        public ObservableRangeCollection<WarehouseModel> WarehouseList
        {
            get => _warehouseList;
            set => SetProperty(ref this._warehouseList, value);
        }

        public string UserID { get => _userid; set => SetProperty(ref _userid, value); }
        public string Password { get => _password; set => SetProperty(ref _password, value); }
    }
}
