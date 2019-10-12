using SimpleMVVM.Behaviors;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SimpleMVVM.Sorting;
using SimpleMVVM.ViewModels;

namespace SimpleMVVM.Controls
{
    public class DataGridHeader : Label
    {
        public string FieldName { get; set; }

        private EventToCommandBehavior etcb;

        public SortingOrder SortFlag { get; set; }

        public static readonly BindableProperty SortingEnabledProperty = BindableProperty.Create(nameof(SortingEnabled), typeof(bool), typeof(DataGridHeader), true);

        public bool SortingEnabled
        {
            get { return (bool)GetValue(SortingEnabledProperty); }
            set { SetValue(SortingEnabledProperty, value); }
        }

        public DataGridHeader()
        {
            var tapGestureRecognizer = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 1
            };

            tapGestureRecognizer.Tapped += (s, e) =>
            {
                etcb.Command = (this.BindingContext as ViewModelBase).SortedCommand;
                Clicked?.Invoke(s, EventArgs.Empty);
            };
            this.GestureRecognizers.Add(tapGestureRecognizer);
            
            etcb = new EventToCommandBehavior();
            etcb.EventName = "Clicked";
            etcb.CommandParameter = this;
            this.Behaviors.Add(etcb);
        }

        //https://stackoverflow.com/questions/35811060/how-to-create-click-event-on-label-in-xamarin-forms-dynamically/35811410
        public event EventHandler Clicked;

        public string Name
        {
            get; set;
        }
    }
}
