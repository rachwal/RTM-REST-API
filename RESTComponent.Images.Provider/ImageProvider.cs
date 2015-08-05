// RESTComponent
// RESTComponent.Images.Provider
// ImageProvider.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System;

namespace RESTComponent.Images.Provider
{
    public class ImageProvider : IImageProvider
    {
        private volatile string currentEncodedImage = string.Empty;
        public event EventHandler NewImage;

        public string EncodedImage
        {
            get { return currentEncodedImage; }
            set
            {
                currentEncodedImage = value;

                if (NewImage != null)
                {
                    NewImage(this, EventArgs.Empty);
                }
            }
        }
    }
}