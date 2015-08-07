// RESTComponent
// RESTComponent.Api
// StatusController.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System;
using System.Globalization;
using System.Web.Http;

namespace RESTComponent.Api.Status
{
    public class StatusController : ApiController, IStatusController
    {
        public string Get()
        {
            return $"Connected\nComponent time: {DateTime.Now.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}