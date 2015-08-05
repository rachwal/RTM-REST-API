// RESTComponent
// RESTComponent.Preview
// PreviewBootstrapper.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using RESTComponent.Api.Manager;
using RESTComponent.CameraImages;
using RESTComponent.Images.Decoder;
using RESTComponent.Images.Decoder.ImageSource;
using RESTComponent.Images.Provider;
using RESTComponent.Preview.View;
using RESTComponent.Preview.ViewModel;
using RESTComponent.RTComponent.Configuration;
using RESTComponent.RTComponent.Manager;

namespace RESTComponent.Preview
{
    public class PreviewBootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            Container.RegisterType<IImageProvider, ImageProvider>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IImagesDecoder<BitmapImage>, BitmapImageDecoder>();

            Container.RegisterType<ICameraImageFactory, CameraImageFactory>();

            Container.RegisterType<IStartup, Startup>();
            Container.RegisterType<IApiManager, ApiManager>(new ContainerControlledLifetimeManager());

            Container.RegisterType<IComponentConfiguration, ComponentConfiguration>(
                new ContainerControlledLifetimeManager());
            Container.RegisterType<IComponentManager, ComponentManager>(new ContainerControlledLifetimeManager());

            Container.RegisterType<IPreviewViewModel, PreviewViewModel>();
            Container.RegisterType<ShellView>();

            base.ConfigureContainer();
        }

        protected override DependencyObject CreateShell()
        {
            var view = Container.TryResolve<ShellView>();
            return view;
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Container.Resolve<IComponentManager>().Start(null);

            App.Current.MainWindow = (Window) Shell;
            App.Current.MainWindow.Show();
        }
    }
}