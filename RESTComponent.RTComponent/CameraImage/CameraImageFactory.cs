// RESTComponent
// RESTComponent.RTComponent
// CameraImageFactory.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Media.Imaging;
using RESTComponent.RTComponent.Configuration;
using RTM.Images.Decoder;
using RTM.Images.Factory;

namespace RESTComponent.RTComponent.CameraImage
{
    public class CameraImageFactory : ICameraImageFactory
    {
        private readonly IImageFactory imageFactory;
        private readonly IImagesDecoder<BitmapImage> bitmapImageDecoder;
        private readonly IImagesDecoder<Bitmap> bitmapDecoder;
        private readonly IComponentConfiguration configuration;

        public CameraImageFactory(IImageFactory image, IImagesDecoder<Bitmap> bitmap,
            IImagesDecoder<BitmapImage> bitmapSource, IComponentConfiguration componentConfiguration)
        {
            configuration = componentConfiguration;
            imageFactory = image;
            bitmapDecoder = bitmap;
            bitmapImageDecoder = bitmapSource;
        }

        public OpenRTM.Core.CameraImage Create(Bitmap bitmap)
        {
            var image = imageFactory.Create(bitmap);
            return new OpenRTM.Core.CameraImage
            {
                Bpp = (ushort) image.Bpp,
                Format = image.Format,
                Width = (ushort) image.Width,
                Height = (ushort) image.Height,
                Pixels = new List<byte>(image.Pixels.ToList().AsReadOnly())
            };
        }

        public OpenRTM.Core.CameraImage Create(BitmapSource bitmapSource)
        {
            var image = imageFactory.Create(bitmapSource);
            return new OpenRTM.Core.CameraImage
            {
                Bpp = (ushort) image.Bpp,
                Format = image.Format,
                Width = (ushort) image.Width,
                Height = (ushort) image.Height,
                Pixels = new List<byte>(image.Pixels.ToList().AsReadOnly())
            };
        }

        public OpenRTM.Core.CameraImage Create(string image)
        {
            if (configuration.PixelFormat == 0)
            {
                var bitmap = bitmapDecoder.Decode(image);
                var cameraImage = Create(bitmap);
                return cameraImage;
            }
            else
            {
                var bitmap = bitmapImageDecoder.Decode(image);
                var cameraImage = Create(bitmap);
                return cameraImage;
            }
        }
    }
}