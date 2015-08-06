// RESTComponent
// RESTComponent.Api
// IImagesController.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using RTM.Images.Provider;

namespace RESTComponent.Api.Images
{
    public interface IImagesController
    {
        IImageProvider Provider { get; set; }
    }
}