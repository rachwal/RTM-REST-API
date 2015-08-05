// RESTComponent
// RESTComponent.Images.Decoder
// IImagesDecoder.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

namespace RESTComponent.Images.Decoder
{
    public interface IImagesDecoder<out T>
    {
        T Decode(string encodedPicture);
    }
}