using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleMVVM.ViewModels
{
    public class ImagePageTestViewModel : ViewModelBase
    {

        public ICommand Image1Command { get; }
        public ICommand Image2Command { get; }
        public ICommand Image3Command { get; }
        
        private Image _image1 = new Image();

        public ImagePageTestViewModel()
        {
            Image1Command = new Command(Image1Run);
            Image2Command = new Command(Image2Run);
            Image3Command = new Command(Image3Run);
        }

        private void Image3Run(object obj)
        {
            Image1.Source = null;
        }

        private void Image1Run(object obj)
        {
            Image1.Source = ImageSource.FromFile("/storage/emulated/0/Android/data/com.companyname.SimpleMVVM/files/Icon120.png");
        }

        private void Image2Run(object obj)
        {
           Image1.Source = ImageSource.FromFile("/storage/emulated/0/Android/data/com.companyname.SimpleMVVM/files/Icon180.png");
        }

        public Image Image1 { get => _image1; set => SetProperty(ref _image1, value); }
    }
}
