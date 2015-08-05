// RESTComponent
// RESTComponent.Images.Decoder.ImageSource
// BitmapImageDecoder.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace RESTComponent.Images.Decoder.ImageSource
{
    public class BitmapImageDecoder : IImagesDecoder<BitmapImage>
    {
        public BitmapImage Decode(string encodedPicture)
        {
            try
            {
                return DecodeToBitmapImage(encodedPicture);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private BitmapImage DecodeToBitmapImage(string encodedPicture)
        {
            var bytes = Convert.FromBase64String(encodedPicture);
            var bitmapImage = new BitmapImage();
            using (var stream = new MemoryStream(bytes))
            {
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = stream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
                return bitmapImage;
            }
        }
    }
}