// RESTComponent
// RESTComponent.CameraImages
// ICameraImageFactory.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System.Drawing;
using OpenRTM.Core;

namespace RESTComponent.CameraImages
{
    public interface ICameraImageFactory
    {
        CameraImage Create(string value);
        CameraImage Create(Bitmap bitmap);
    }
}