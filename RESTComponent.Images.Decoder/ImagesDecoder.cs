// RESTComponent
// RESTComponent.Images.Decoder
// ImagesDecoder.cs
// 
// Created by Bartosz Rachwal.
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved.
// 

using System;
using System.Drawing;
using System.IO;

namespace RESTComponent.Images.Decoder
{
    public class ImagesDecoder : IImagesDecoder
    {
        public Bitmap Decode(string encodedPicture)
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
    }
}