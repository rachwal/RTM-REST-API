// RESTComponent
// RESTComponent.Preview
// PreviewViewModel.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using RESTComponent.Images.Decoder;
using RESTComponent.Images.Provider;
using RESTComponent.Preview.Annotations;

namespace RESTComponent.Preview.ViewModel
{
    public class PreviewViewModel : IPreviewViewModel, INotifyPropertyChanged
    {
        private readonly IImageProvider provider;
        private readonly IImagesDecoder<BitmapImage> decoder;

        public ImageSource PreviewImage { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public PreviewViewModel(IImageProvider imageProvider, IImagesDecoder<BitmapImage> imagesDecoder)
        {
            decoder = imagesDecoder;
            provider = imageProvider;
            provider.NewImage += OnNewImage;
        }

        private void OnNewImage(object sender, EventArgs e)
        {
            PreviewImage = decoder.Decode(provider.EncodedImage);
            OnPropertyChanged(nameof(PreviewImage));
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}