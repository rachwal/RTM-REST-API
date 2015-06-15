// RESTComponent
// RESTComponent.ImagesProvider
// IImageProvider.cs
// 
// Created by Bartosz Rachwal.
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved.
// 
using System;

namespace RESTComponent.ImagesProvider
{
    public interface IImageProvider
    {
        string EncodedImage { get; set; }
        event EventHandler NewImage;
    }
}
