// RESTComponent
// RESTComponent.CameraImages
// CameraImageFactory.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using OpenRTM.Core;
using RTM.Images.Decoder;

namespace RESTComponent.CameraImages
{
    public class CameraImageFactory : ICameraImageFactory
    {
        private readonly IImagesDecoder<Bitmap> decoder;

        public CameraImageFactory(IImagesDecoder<Bitmap> imagesDecoder)
        {
            decoder = imagesDecoder;
        }

        public CameraImage Create(string value)
        {
            var bitmap = decoder.Decode(value);
            var cameraImage = Create(bitmap);
            return cameraImage;
        }

        public CameraImage Create(Bitmap bitmap)
        {
            var cameraImage = new CameraImage();
            if (bitmap == null)
                return cameraImage;

            var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            var bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);
            var length = bitmapData.Stride*bitmapData.Height;
            var outputPixels = new byte[length];
            Marshal.Copy(bitmapData.Scan0, outputPixels, 0, length);
            bitmap.UnlockBits(bitmapData);

            var bitsPerPixel = (ushort) ((int) bitmap.PixelFormat >> 8 & 0xFF);

            cameraImage.Bpp = bitsPerPixel;
            cameraImage.Width = (ushort) bitmap.Width;
            cameraImage.Height = (ushort) bitmap.Height;
            cameraImage.Pixels = outputPixels.ToList();

            return cameraImage;
        }
    }
}