using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using SimpleMVVM.Sorting;
using SimpleMVVM.Controls;
using SimpleMVVM.Models;
using SimpleMVVM.ViewModels;

namespace SimpleMVVM.ViewModels
{
    public class EmpViewModel : ViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableRangeCollection<EmpModel> _empList = new ObservableRangeCollection<EmpModel>();

        private string _result;

        private string _empId;
        private string _empName;

        private EmpModel _selectedItem;

        public ICommand SendCommand { get; } //생성자에서만 new할꺼면 private set없어도 된다.

        public ICommand ReturnValueCommand { get; }
        
        //public ICommand SortedCommand { get; set; }

        public EmpViewModel()
        {
            SendCommand = new Command(() => Send());
            ReturnValueCommand = new Command(() => Return());
            SortedCommand = new Command<DataGridHeader>(Sorted);

        }

        private void Sorted(DataGridHeader e)
        {
            Console.WriteLine(e.SortFlag);
            Console.WriteLine(e.SortingEnabled);
            Console.WriteLine(e.FieldName);

            if(!e.SortingEnabled)
            {
                return;
            }

            SortingOrder sortMethod;
            
            if (e.SortFlag ==  SortingOrder.None || e.SortFlag == SortingOrder.Ascendant)
            {
                sortMethod = SortingOrder.Descendant;
            }
            else
            {
                sortMethod = SortingOrder.Ascendant;
            }

            e.SortFlag = sortMethod;
            List<EmpModel> lst = EmpList.ToList();

            SortData.SortList(ref lst, e.SortFlag, e.FieldName);
            EmpList.Clear();
            EmpList.AddRange(lst, System.Collections.Specialized.NotifyCollectionChangedAction.Reset);
            //EmpList = new ObservableRangeCollection<EmpModel>(lst);
                       
            lst.Clear();
        }

        private void Return()
        {
            Debug.WriteLine("return");
        }

        private void Send()
        {
            List<EmpModel> Employees = new List<EmpModel>()
            {
                new EmpModel {EmpId = 1,  EmpName = "첫번째", Addr="주소, 첫번째", Age = 11, GradeCode = "001"},
                new EmpModel {EmpId = 2,  EmpName = "두번째", Addr="주소, 두번째", Age = 12, GradeCode = "002"},
                new EmpModel {EmpId = 3,  EmpName = "세번째", Addr="주소, 세번째", Age = 13, GradeCode = "003"},
                new EmpModel {EmpId = 4,  EmpName = "네번째", Addr="주소, 네번째", Age = 14, GradeCode = "004"},
                new EmpModel {EmpId = 5,  EmpName = "다섯번째", Addr="주소, 다섯번째", Age = 15, GradeCode = "001"},
                new EmpModel {EmpId = 6,  EmpName = "여섯번째", Addr="주소, 여섯번째", Age = 16, GradeCode = "002"},
                new EmpModel {EmpId = 7,  EmpName = "여섯번째", Addr="주소, 일곱번째", Age = 17, GradeCode = "003"},
                new EmpModel {EmpId = 8,  EmpName = "여덟번째", Addr="주소, 여덟번째", Age = 18, GradeCode = "004"},
                new EmpModel {EmpId = 9,  EmpName = "아홉번째", Addr="주소, 아홉번째", Age = 19, GradeCode = "001"},
                new EmpModel {EmpId = 10,  EmpName = "열번째", Addr="주소, 열번째", Age = 20, GradeCode = "002"}

                //new EmpModel {EmpId = 1,  EmpName = "첫번째", Addr="주소, 첫번재", Age = 11, SelectedRow=0},
                //new EmpModel {EmpId = 2,  EmpName = "두번째", Addr="주소, 두번째", Age = 12, SelectedRow=1},
                //new EmpModel {EmpId = 3,  EmpName = "세번째", Addr="주소, 세번째", Age = 13, SelectedRow=2},
                //new EmpModel {EmpId = 4,  EmpName = "네번째", Addr="주소, 네번째", Age = 14, SelectedRow=3},
                //new EmpModel {EmpId = 5,  EmpName = "다섯번째", Addr="주소, 다섯번째", Age = 15, SelectedRow=0},
                //new EmpModel {EmpId = 6,  EmpName = "여섯번째", Addr="주소, 여섯번째", Age = 16, SelectedRow=1},
                //new EmpModel {EmpId = 7,  EmpName = "여섯번째", Addr="주소, 일곱번째", Age = 17, SelectedRow=2},
                //new EmpModel {EmpId = 8,  EmpName = "여덟번째", Addr="주소, 여덟번째", Age = 18, SelectedRow=3},
                //new EmpModel {EmpId = 9,  EmpName = "아홉번째", Addr="주소, 아홉번째", Age = 19, SelectedRow=4},
                //new EmpModel {EmpId = 10,  EmpName = "열번째", Addr="주소, 열번째", Age = 20, SelectedRow=0}

            };

            EmpList.AddRange(Employees);

            //foreach (var item in EmpList)
            //{
            //    Console.WriteLine(item.Grade.Code + ", " + item.GradeCode);
            //}

            //EmpList.Clear();
            //for (int i = 0; i < 100; i++)
            //{
            //    EmpList.Add(new EmpModel { EmpId = i, EmpName = "test", Addr = i.ToString() + "addr", Age = i, Money = 5000 });
            //}

            //SelectedItem = EmpList.Skip(2).FirstOrDefault();

            //EmpList.Add(new EmpModel
            //    {
            //        EmpId = this.EmpId,
            //        EmpName = this.EmpName
            //    }
            //);
        }


        public string Result
        {
            set
            {
                if (_result == value) return;                
                _result = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Result"));

                //if (PropertyChanged != null)
                //{
                //    PropertyChanged(this, new PropertyChangedEventArgs("Result"));
                //}
            }

            get { return _result;}
        }

        public string EmpId
        {
            set
            {
                if (_empId == value) return;
                _empId = value;

               NotifyPropertyChanged();
               //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EmpId"));
            }

            get { return _empId; }
        }

        public string EmpName
        {
            set
            {
                if (_empName == value) return;
                _empName = value;

                NotifyPropertyChanged();
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(EmpName));
            }

            get { return _empName; }
        }

        public ObservableRangeCollection<EmpModel> EmpList
        {
            get { return _empList; }

            set
            {
                if (_empList == value) return;
                _empList = value;

                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            //if(PropertyChanged != null)
            //{
            //    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            //}

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public EmpModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                }
            }
        }
    }
}
