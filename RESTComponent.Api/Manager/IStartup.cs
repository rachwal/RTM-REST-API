// RESTComponent
// RESTComponent.Api
// IStartup.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using Owin;

namespace RESTComponent.Api.Manager
{
    public interface IStartup
    {
        void Configuration(IAppBuilder appBuilder);
    }
}