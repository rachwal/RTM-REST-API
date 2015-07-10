RTM-REST-API
========================
What is RTM REST API? 
------------
RTM REST API is a free, open source Robotic Technology Middleware component that supports communication between OpenRTM platform and remote clients using REST API. Clients of this component can run anywhere, and they don't require you to use a particular programming language or framework. Please refer to [OpenRTM](http://openrtm.org/) for general framework insights and documentation of the platform. RTM REST API is extensible. You can write component extensions that change the behavior of the component, or add new capabilities.

What Does RTM REST API Do? 
------------
You can use the RTM REST API to stream video from remote device to OpenRTM platform using HTTP protocol. Component exposes POST method named 'images' that you can use send jpeg image encoded as 64 bit string.

Getting started
---------------
The system requirements and prerequisites for using RTM REST API are:
* Supported architectures: x86 and x64.
* Operating systems: Microsoft Windows 8, Microsoft Windows 7, Windows Server 2008 R2, Windows
Server 2012.
* Supported .NET Frameworks: Microsoft .NET Framework 4.5 or higher
* Microsoft [Visual Studio](https://www.visualstudio.com).
You can use the [NuGet package manager](https://visualstudiogallery.msdn.microsoft.com/27077b70-9dad-4c64-adcf-c7cf6bc9970c) in Visual Studio to install the [Unity Container](https://msdn.microsoft.com/en-us/library/ff647202.aspx) and [Microsoft ASP.NET Web API 2.2 OWIN Self Host](https://www.nuget.org/packages/Microsoft.AspNet.WebApi.OwinSelfHost) assemblies in component.
* [OpenRTM.NET](http://www.sec.co.jp/robot/download_rtm.html) 1.3.1 or higher 

Download or Clone this repository from Github. Open RESTComponent.sln and Build.

Get free client app!
---------------
<a href="https://itunes.apple.com/us/app/rtm-client/id1009085714?ls=1&mt=8">
<img class="centered" src="http://rachwal.github.io/RTM-REST-API/images/Download_on_the_App_Store_Badge_US-UK_135x40.svg" alt="RTM Client"/>
</a>