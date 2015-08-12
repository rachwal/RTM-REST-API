// RESTComponent
// RESTComponent.RTComponent
// ICameraImageFactory.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System.Drawing;
using System.Windows.Media.Imaging;

namespace RESTComponent.RTComponent.CameraImage
{
    public interface ICameraImageFactory
    {
        OpenRTM.Core.CameraImage Create(Bitmap bitmap);
        OpenRTM.Core.CameraImage Create(BitmapSource bitmapSource);
        OpenRTM.Core.CameraImage Create(string image);
    }
}