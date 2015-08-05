// RESTComponent
// RESTComponent.Api
// ImagesController.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System.Web.Http;
using Microsoft.Practices.Unity;
using RESTComponent.Images.Provider;

namespace RESTComponent.Api.Images
{
    public class ImagesController : ApiController, IImagesController
    {
        [Dependency]
        public IImageProvider Provider { get; set; }

        public void Post([FromBody] dynamic encodedImage)
        {
            var source = encodedImage.data.Value;
            Provider.EncodedImage = source;
        }
    }
}