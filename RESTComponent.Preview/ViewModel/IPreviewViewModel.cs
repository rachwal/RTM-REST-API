// RESTComponent
// RESTComponent.Preview
// IPreviewViewModel.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 Bartosz Rachwal. The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System.Windows.Media;

namespace RESTComponent.Preview.ViewModel
{
    public interface IPreviewViewModel
    {
        ImageSource PreviewImage { get; set; }
    }
}