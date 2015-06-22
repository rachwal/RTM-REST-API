// RESTComponent
// RESTComponent.RTComponent
// ComponentManager.cs
// 
// Created by Bartosz Rachwal.
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved.
// 
using System;
using System.Threading.Tasks;
using OpenRTM.Extension;
using OpenRTM.IIOP;
using RESTComponent.Api.Manager;
using RESTComponent.ImagesProvider;
using RESTComponent.RTComponent.Component;
using RESTComponent.RTComponent.Configuration;
using RESTComponent.RTComponent.ImageFactory;

namespace RESTComponent.RTComponent.Manager
{
    public class ComponentManager : IComponentManager
    {
        private readonly IApiManager apiManager;
        private readonly ICameraImageFactory cameraImageFactory;
        private readonly IComponentConfiguration componentConfiguration;
        private readonly IImageProvider imageProvider;

        public ComponentManager(IImageProvider provider, ICameraImageFactory factory, IComponentConfiguration configuration, IApiManager manager)
        {
            apiManager = manager;
            componentConfiguration = configuration;
            cameraImageFactory = factory;
            imageProvider = provider;
        }

        public void Start(string[] args)
        {
            Task.Factory.StartNew(() =>
            {
                var manager = new OpenRTM.Core.Manager(args);
                manager.AddTypes(typeof(CorbaProtocolManager));
                manager.Activate();
                try
                {
                    var comp = manager.CreateComponent<CameraStream>();
                    comp.ImageProvider = imageProvider;
                    comp.CameraImageFactory = cameraImageFactory;
                    comp.Configuration = componentConfiguration;
                    comp.ApiManager = apiManager;

                    Console.WriteLine(comp.GetComponentProfile().Format());

                    manager.Run();
                }
                catch (Exception)
                {
                    Console.WriteLine();
                    Console.WriteLine("StartAsync naming service before running component");
                    Console.WriteLine(@"More info at http://www.openrtm.org/openrtm/en/node/1420");
                }
            });
        }
    }
}
