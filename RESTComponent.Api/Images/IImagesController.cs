// RESTComponent
// RESTComponent.Api
// IImagesController.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 Bartosz Rachwal. The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

namespace RESTComponent.Api.Images
{
    public interface IImagesController
    {
        IImageProvider Provider { get; set; }
    }
}