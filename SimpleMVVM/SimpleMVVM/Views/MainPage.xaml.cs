using SimpleMVVM.Models;
using SimpleMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SimpleMVVM
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //this.H0.BindingContext = this.BindingContext;

            //this.EmpId.CursorPosition = 2;
            //this.EmpId.SelectionLength = 2;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var dataTemplate = new DataTemplate(() =>
            {
                var grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.2, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star) });

                var nameLabel = new Label { FontAttributes = FontAttributes.Bold };
                var ageLabel = new Label();
                var locationLabel = new Label { HorizontalTextAlignment = TextAlignment.Center };

                nameLabel.SetBinding(Label.TextProperty, "EmpId");
                ageLabel.SetBinding(Label.TextProperty, "EmpId");
                locationLabel.SetBinding(Label.TextProperty, "EmpId");

                grid.Children.Add(nameLabel);
                grid.Children.Add(ageLabel, 1, 0);
                grid.Children.Add(locationLabel, 2, 0);

                return grid;
            });

            collectionView.ItemTemplate = dataTemplate;
            collectionView.Margin = new Thickness(0, 20, 0, 0);

            Grid _grid = (this.cvDt.CreateContent() as Grid);

            var dcols = (this.cvDt.CreateContent() as Grid).ColumnDefinitions;

            dcols[0].Width = 100;
            //Grid.SetColumn((BindableObject)dcols[1], 0);
            //this.cvDt.SetValue(Grid.ColumnDefinitionsProperty, dcols); //변경된 내역 적용

            var dcols_children = (this.cvDt.CreateContent() as Grid).Children;

            int i = 0;
            foreach (var item in dcols_children)
            {
                if (item is Label)
                {
                    Label label = new Label();
                    label.SetBinding(Label.TextProperty, "EmpId");
                    item.BindingContext = label;

                    //item.SetBinding(Label.TextProperty, "EmpId");

                    //item.Setbi(Label.BackgroundColorProperty, item);

                    //item.SetBinding(Label.TextProperty, new Binding("EmpId", BindingMode.Default));
                    //item.SetBinding(BindingContextProperty, new Binding("EmpId", source: BindingContext));


                    //(_grid as Grid).SetValue(BindingContextProperty, item);


                }
                i++;
            }


            //this.cvDt.SetValue(Grid.BindingContextProperty, dcols_children);

            //collectionView.SetValue(CollectionView.ItemTemplateProperty, this.cvDt);

            //Grid.SetColumn((BindableObject)dcols[1], 0);
            //this.cvDt.SetValue(Grid.ColumnDefinitionsProperty, dcols_children);
        }

        private void MoveButton_Clicked(object sender, EventArgs e)
        {
            //collectionView.ScrollTo(30);

            //collectionView.SelectedItem = new EmpModel { EmpId = "50", EmpName = "test", Addr = "addr", Age = 12, Money = 5000 };

        }

        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            Console.WriteLine(e.ToString());
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Console.WriteLine("=========================== test");
        }

        private void CollectionView_Focused(object sender, FocusEventArgs e)
        {
            Console.WriteLine(((CollectionView)sender).SelectedItem);
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(((CollectionView)sender).SelectedItem);
            Console.WriteLine(e.CurrentSelection);

            //int previous = (e.PreviousSelection.FirstOrDefault() as EmpModel)?.EmpId;
            //int current = (e.CurrentSelection.FirstOrDefault() as EmpModel)?.EmpId;

            //라인이동
            //this.collectionView.ScrollTo(30, 0, ScrollToPosition.Start, false);
        }

        private void CollectionView_ScrollToRequested(object sender, ScrollToRequestEventArgs e)
        {
            Console.WriteLine("ScrollToRequested : " + e.Index);
        }


        private void H0_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("aa");
        }

        private void AgeEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            int age;
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                return;
            }

            if (Int32.TryParse(e.NewTextValue, out int j))
            {
                Console.WriteLine(j);
                age = j;
            }
            else
            {
                Console.WriteLine("String could not be parsed.");
                // Output: -105
                return;
            }

            if (((Entry)sender).ReturnCommandParameter == null)
            {
                return;
            }
            EmpModel selectedItem = (EmpModel)(BindingContext as EmpViewModel).EmpList.Where(i => i.EmpId == (int)((Entry)sender).ReturnCommandParameter).FirstOrDefault();
            this.collectionView.SelectedItem = selectedItem;
        }

        private void AgeEntry_Unfocused(object sender, FocusEventArgs e)
        {
            this.collectionView.SelectedItem = null;
        }

        private void AgeEntry_Focused(object sender, FocusEventArgs e)
        {
            Console.WriteLine(e.ToString());

            Console.WriteLine("==> " + ((Entry)sender).ReturnCommandParameter);

            EmpModel selectedItem = (EmpModel)(BindingContext as EmpViewModel).EmpList.Where(i => i.EmpId == (int)((Entry)sender).ReturnCommandParameter).FirstOrDefault();
            this.collectionView.SelectedItem = selectedItem;
        }
    }
}
