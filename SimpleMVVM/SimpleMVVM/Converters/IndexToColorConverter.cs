﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SimpleMVVM.Converters
{
    public class IndexToColorConverter : IValueConverter
    {
        public Color EvenColor { get; set; }

        public Color OddColor { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var collectionView = parameter as CollectionView;

            return collectionView.ItemsSource.Cast<object>().IndexOf(value) % 2 == 0 ? EvenColor : OddColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
