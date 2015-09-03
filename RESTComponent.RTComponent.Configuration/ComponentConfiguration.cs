// RESTComponent
// RESTComponent.RTComponent.Configuration
// ComponentConfiguration.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 Bartosz Rachwal. The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System;

namespace RESTComponent.RTComponent.Configuration
{
    public class ComponentConfiguration : IComponentConfiguration
    {
        private string defaultHost = "+";
        private int defaultPort = 9000;
        private int pixelFormat;

        public int PixelFormat
        {
            get { return pixelFormat; }
            set
            {
                if (value == pixelFormat)
                {
                    return;
                }

                pixelFormat = value;

                ConfigurationChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler ConfigurationChanged;

        public int Port
        {
            get { return defaultPort; }
            set
            {
                if (value == defaultPort)
                {
                    return;
                }

                defaultPort = value;

                ConfigurationChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public string Host
        {
            get { return defaultHost; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    return;

                var newHost = value.Trim().ToLower() == "localhost" ? "+" : value;

                if (newHost.Equals(defaultHost))
                {
                    return;
                }

                defaultHost = newHost;

                ConfigurationChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}