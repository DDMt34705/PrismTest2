using Event;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ImageDisplay.ViewModels
{
    public static class BitmapConversion
    {
        public static BitmapSource BitmapToBitmapSource(Bitmap source)
        {
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                          source.GetHbitmap(),
                          IntPtr.Zero,
                          Int32Rect.Empty,
                          BitmapSizeOptions.FromEmptyOptions());
        }
    }

    public class ImageDisplayViewModel : BindableBase
    {
        private BitmapSource _imageSource;
        public BitmapSource ImageSource
        {
            get { return _imageSource; }
            set { SetProperty(ref _imageSource, value); }
        }

        //private BitmapSource _bitmapSource;

        private IEventAggregator _eventAggregator;
        public ImageDisplayViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<FileSelectEvent>().Subscribe(HandleFileSelect);

            HandleFileSelect(@"c:\temp\test.jpg");
        }

        private void HandleFileSelect(string fileName)
        {
            Bitmap bitmap = (Bitmap)Bitmap.FromFile(fileName, true);
            ImageSource = BitmapConversion.BitmapToBitmapSource(bitmap);
        }

        //public BitmapSource ButtonSource
        //{
        //    get { return _bitmapSource; }
        //}
    }
}
