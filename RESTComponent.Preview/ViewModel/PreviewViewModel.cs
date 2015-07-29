// RESTComponent
// RESTComponent.Preview
// PreviewViewModel.cs
// 
// Created by Bartosz Rachwal.
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved.
// 

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using RESTComponent.ImagesProvider;
using RESTComponent.Preview.Annotations;

namespace RESTComponent.Preview.ViewModel
{
    public class PreviewViewModel : IPreviewViewModel, INotifyPropertyChanged
    {
        private readonly IImageProvider provider;

        public PreviewViewModel(IImageProvider imageProvider)
        {
            provider = imageProvider;
            provider.NewImage += OnNewImage;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ImageSource PreviewImage { get; set; }

        private void OnNewImage(object sender, EventArgs e)
        {
            var bitmap = Decode(provider.EncodedImage);
            var imageSource = Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
            PreviewImage = imageSource;
            PreviewImage.Freeze();
            OnPropertyChanged("PreviewImage");
        }

        private Bitmap Decode(string encodedPicture)
        {
            try
            {
                var bytes = Convert.FromBase64String(encodedPicture);

                Bitmap decoded;
                using (var stream = new MemoryStream(bytes))
                {
                    decoded = new Bitmap(stream);
                }
                return decoded;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}