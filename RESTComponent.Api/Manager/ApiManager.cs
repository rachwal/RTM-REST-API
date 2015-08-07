// RESTComponent
// RESTComponent.Api
// ApiManager.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using RESTComponent.RTComponent.Configuration;

namespace RESTComponent.Api.Manager
{
    public class ApiManager : IApiManager
    {
        private readonly IComponentConfiguration componentConfiguration;
        private readonly IStartup startupConfiguration;
        private volatile bool isRunning;
        private CancellationTokenSource tokenSource;

        public ApiManager(IComponentConfiguration configuration, IStartup startup)
        {
            startupConfiguration = startup;
            componentConfiguration = configuration;
            componentConfiguration.ConfigurationChanged += OnConfigurationChanged;
        }

        public void StartAsync()
        {
            if (isRunning)
                return;

            isRunning = true;
            tokenSource = new CancellationTokenSource();

            Task.Factory.StartNew(() =>
            {
                var address = $"http://{componentConfiguration.Host}:{componentConfiguration.Port}";

                var options = new StartOptions(address)
                {
                    ServerFactory = "Microsoft.Owin.Host.HttpListener"
                };

                using (WebApp.Start(options, appBuilder => { startupConfiguration.Configuration(appBuilder); }))
                {
                    Console.WriteLine("Started {0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    while (true)
                    {
                        if (!tokenSource.Token.IsCancellationRequested)
                        {
                            continue;
                        }
                        isRunning = false;
                        return;
                    }
                }
            }, tokenSource.Token);
        }

        public void Stop()
        {
            tokenSource?.Cancel();
        }

        private void OnConfigurationChanged(object sender, EventArgs e)
        {
            Stop();
        }
    }
}