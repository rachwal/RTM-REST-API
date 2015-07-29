// RESTComponent
// RESTComponent.RTComponent.Configuration
// IComponentConfiguration.cs
// 
// Created by Bartosz Rachwal.
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved.
// 

using System;

namespace RESTComponent.RTComponent.Configuration
{
    public interface IComponentConfiguration
    {
        int Port { get; set; }
        string Host { get; set; }
        event EventHandler ConfigurationChanged;
    }
}