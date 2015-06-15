// RESTComponent
// RESTComponent.RTComponent
// CameraImageFactory.cs
// 
// Created by Bartosz Rachwal.
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved.
// 
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using OpenRTM.Core;

namespace RESTComponent.RTComponent.ImageFactory
{
    public class CameraImageFactory : ICameraImageFactory
    {
        public CameraImage Create(string value)
        {
            var bitmap = Decode(value);
            var cameraImage = CopyBytes(bitmap);
            return cameraImage;
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

        private CameraImage CopyBytes(Bitmap bitmap)
        {
            var cameraImage = new CameraImage();
            if (bitmap == null)
                return cameraImage;

            var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            var bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);
            var length = bitmapData.Stride * bitmapData.Height;
            var outputPixels = new byte[length];
            Marshal.Copy(bitmapData.Scan0, outputPixels, 0, length);
            bitmap.UnlockBits(bitmapData);

            var bitsPerPixel = (ushort)((int)bitmap.PixelFormat >> 8 & 0xFF);

            cameraImage.Bpp = bitsPerPixel;
            cameraImage.Width = (ushort)bitmap.Width;
            cameraImage.Height = (ushort)bitmap.Height;
            cameraImage.Pixels = outputPixels.ToList();

            return cameraImage;
        }
    }
}