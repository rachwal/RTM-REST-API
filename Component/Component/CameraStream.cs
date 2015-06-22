// RESTComponent
// RESTComponent.RTComponent
// CameraStream.cs
// 
// Created by Bartosz Rachwal.
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved.
// 
using System;
using System.Linq;
using OpenRTM.Core;
using OpenRTM.Extension;
using RESTComponent.Api.Manager;
using RESTComponent.ImagesProvider;
using RESTComponent.RTComponent.Configuration;
using RESTComponent.RTComponent.ImageFactory;

namespace RESTComponent.RTComponent.Component
{
    [Component(Category = "RESTCameraComponent", Name = "RESTCamera")]
    [DetailProfile(
        Description = "REST Camera Component",
        Language = "C#",
        LanguageType = "Compile",
        MaxInstance = 1,
        Vendor = "AIST",
        Version = "1.0.0")]
    [CustomProfile("CreationDate", "2015/06/15")]
    [CustomProfile("Author", "Bartosz Rachwal")]
    public class CameraStream : DataFlowComponent
    {
        [OutPort(PortName = "out")]
        private readonly OutPort<CameraImage> outport = new OutPort<CameraImage>();

        private ConfigurationSet configurationSet;
        private int handle;

        public CameraStream()
        {
            Config.OnSetConfigurationSet += UpdateConfiguration;
        }

        public IImageProvider ImageProvider { get; set; }
        public ICameraImageFactory CameraImageFactory { get; set; }
        public IComponentConfiguration Configuration { get; set; }
        public IApiManager ApiManager { get; set; }

        [Configuration(DefaultValue = "localhost", Name = "host")]
        public string Host
        {
            get
            {
                return Configuration != null ? Configuration.Host : "localhost";
            }
            set
            {
                if (Configuration != null)
                {
                    Configuration.Host = value;
                }
            }
        }

        [Configuration(DefaultValue = "9000", Name = "port")]
        public int Port
        {
            get
            {
                return Configuration != null ? Configuration.Port : 9000;
            }
            set
            {
                if (Configuration != null)
                {
                    Configuration.Port = value;
                }
            }
        }

        protected override ReturnCode_t OnActivated(int execHandle)
        {
            handle = execHandle;
            ImageProvider.NewImage += ImageProviderNewImage;
            ApiManager.StartAsync();
            return base.OnActivated(execHandle);
        }

        protected override ReturnCode_t OnDeactivated(int execHandle)
        {
            handle = execHandle;
            ApiManager.Stop();
            ImageProvider.NewImage -= ImageProviderNewImage;
            return base.OnDeactivated(execHandle);
        }

        private void ImageProviderNewImage(object sender, EventArgs e)
        {
            var value = ImageProvider.EncodedImage;
            var newImage = CameraImageFactory.Create(value);
            outport.Write(newImage);
        }

        private void UpdateConfiguration(ConfigurationSet obj)
        {
            if (obj == null)
                return;

            if (configurationSet == null)
            {
                configurationSet = obj;
                return;
            }

            if (obj.Id != configurationSet.Id)
                return;

            foreach (var entry in obj.ConfigurationData)
            {
                if (configurationSet.ConfigurationData.ContainsKey(entry.Key))
                {
                    configurationSet.ConfigurationData[entry.Key] = entry.Value;
                }
                else
                {
                    configurationSet.ConfigurationData.Add(entry.Key, entry.Value);
                }
            }

            Config.OnSetConfigurationSet -= UpdateConfiguration;
            
            this.Deactivate(handle);
            
            foreach (var entry in configurationSet.ConfigurationData)
            {
                this.AddConfigurationValue(entry.Key, entry.Value.ToString());
            }
          
            Config.OnSetConfigurationSet += UpdateConfiguration;
        }
    }
}
