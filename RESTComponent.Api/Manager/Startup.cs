// RESTComponent
// RESTComponent.Api
// Startup.cs
// 
// Created by Bartosz Rachwal.
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved.
// 
using System.Web.Http;
using Microsoft.Practices.Unity;
using Owin;
using Unity.WebApi;

namespace RESTComponent.Api.Manager
{
    public class Startup : IStartup
    {
        private readonly IUnityContainer unityContainer;

        public Startup(IUnityContainer container)
        {
            unityContainer = container;
        }

        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.DependencyResolver = new UnityDependencyResolver(unityContainer.CreateChildContainer());
            appBuilder.UseWebApi(config);
        }
    }
}
