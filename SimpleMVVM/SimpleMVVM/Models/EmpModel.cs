using SimpleMVVM.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;

namespace SimpleMVVM.Models
{
    public class EmpModel  : BindableObject
    {
        public ICommand PlusButtonCommand { get; }
        public ICommand MinusButtonCommand { get; }        

        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Addr { get; set; }

        private int _age;
        private int _selectedRow;
        private string _gradeCode;
        private List<ComboBoxModel> lst;
        public ComboBoxModel _grade;

        private ObservableRangeCollection<ComboBoxModel> _grades = new ObservableRangeCollection<ComboBoxModel>();
        
        public EmpModel()
        {
            PlusButtonCommand = new Command(() => PlusButton());
            MinusButtonCommand = new Command(() => MinusButton());

            lst = new List<ComboBoxModel>
            {
                new ComboBoxModel {Code="001", Name="1학년"},
                new ComboBoxModel {Code="002", Name="2학년"},
                new ComboBoxModel {Code="003", Name="3학년"},
                new ComboBoxModel {Code="004", Name="4학년"}
            };
            
            Grades.AddRange(lst);
        }

        public ComboBoxModel Grade
        {
            get { return this._grade; }
            set
            {
                if (_grade == value || value == null) return;
                _grade = value;
                GradeCode = _grade.Code;
                OnPropertyChanged("Grade");
            }
        }

        public string GradeCode
        {
            get { return this._gradeCode; }
            set
            {
                if (_gradeCode == value) return;
                this._gradeCode = value;
                var row = lst.FirstOrDefault(t => t.Code == value);
                Grade = row;
                OnPropertyChanged("GradeCode");
                //SelectedRow = lst.IndexOf(row);
            }
        }


        public int SelectedRow
        {
            get { return this._selectedRow; }
            set
            {
                if (_selectedRow == value) return;
                this._selectedRow = value;
                OnPropertyChanged("SelectedRow");
            }
        }

        public int Age
        {
            get { return this._age; }
            set
            {
                if (_age == value) return;
                this._age = value;
                OnPropertyChanged("Age");
            }
        }

        private void MinusButton()
        {
            Age -= 1;
        }

        private void PlusButton()
        {
            Age += 1;
        }

        public ObservableRangeCollection<ComboBoxModel> Grades
        {
            get { return this._grades; }
            set
            {
                if (_grades == value) return;
                this._grades = value;
                OnPropertyChanged("Grades");
            }
        }
    }
}
