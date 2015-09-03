// RESTComponent
// RESTComponent.Preview
// PreviewViewModel.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 Bartosz Rachwal. The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using RESTComponent.Api.Images;
using RESTComponent.Preview.Annotations;
using RTM.Images.Decoder;

namespace RESTComponent.Preview.ViewModel
{
    public class PreviewViewModel : IPreviewViewModel, INotifyPropertyChanged
    {
        private readonly IImagesDecoder<BitmapImage> decoder;
        private readonly IImageProvider provider;

        public PreviewViewModel(IImageProvider imageProvider, IImagesDecoder<BitmapImage> imagesDecoder)
        {
            decoder = imagesDecoder;
            provider = imageProvider;
            provider.NewImage += OnNewImage;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ImageSource PreviewImage { get; set; }

        private void OnNewImage(object sender, EventArgs e)
        {
            PreviewImage = decoder.Decode(provider.EncodedImage);
            OnPropertyChanged(nameof(PreviewImage));
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}