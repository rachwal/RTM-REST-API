// RESTComponent
// RESTComponent.RTComponent
// ICameraImageFactory.cs
// 
// Created by Bartosz Rachwal.
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved.
// 
using OpenRTM.Core;

namespace RESTComponent.RTComponent.ImageFactory
{
    public interface ICameraImageFactory
    {
        CameraImage Create(string value);
    }
}