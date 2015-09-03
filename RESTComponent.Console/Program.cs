// RESTComponent
// RESTComponent.Console
// Program.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 Bartosz Rachwal. The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System.Drawing;
using System.Windows.Media.Imaging;
using Microsoft.Practices.Unity;
using RESTComponent.Api.Images;
using RESTComponent.Api.Manager;
using RESTComponent.RTComponent.CameraImage;
using RESTComponent.RTComponent.Configuration;
using RESTComponent.RTComponent.Manager;
using RTM.Images.Decoder;
using RTM.Images.Decoder.ImageSource;
using RTM.Images.Factory;
using BitmapDecoder = RTM.Images.Decoder.Bitmap.BitmapDecoder;

namespace RESTComponent.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RunComponent(args);
            WaitForExit();
        }

        private static void RunComponent(string[] args)
        {
            var container = new UnityContainer();

            container.RegisterType<IImageProvider, ImageProvider>(new ContainerControlledLifetimeManager());
            container.RegisterType<IImagesDecoder<BitmapImage>, BitmapImageDecoder>();
            container.RegisterType<IImagesDecoder<Bitmap>, BitmapDecoder>();
            container.RegisterType<IBitmapFactory, BitmapFactory>();
            container.RegisterType<IBitmapSourceFactory, BitmapSourceFactory>();
            container.RegisterType<IImageFactory, ImageFactory>();
            container.RegisterType<ICameraImageFactory, CameraImageFactory>();

            container.RegisterType<IStartup, Startup>();
            container.RegisterType<IApiManager, ApiManager>(new ContainerControlledLifetimeManager());

            container.RegisterType<IComponentConfiguration, ComponentConfiguration>(
                new ContainerControlledLifetimeManager());
            container.RegisterType<IComponentManager, ComponentManager>(new ContainerControlledLifetimeManager());

            container.Resolve<IComponentManager>().Start(args);
        }

        private static void WaitForExit()
        {
            var run = true;
            while (run)
            {
                var text = System.Console.ReadLine();
                if (string.IsNullOrEmpty(text))
                    continue;
                if (text.Trim().ToLower().Equals("exit"))
                {
                    run = false;
                }
            }
        }
    }
}