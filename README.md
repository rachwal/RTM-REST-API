RTM-REST-API
========================
What is RTM REST API? 
------------
RTM REST API is a free, open source Robotic Technology Middleware component that supports communication between OpenRTM platform and remote clients using REST API. Clients of this component can run anywhere, and they don't require you to use a particular programming language or framework. Please refer to [OpenRTM](http://openrtm.org/) for general framework insights and documentation of the platform. RTM REST API is extensible. You can write component extensions that change the behavior of the component, or add new capabilities.

What Does RTM REST API Do? 
------------
You can use the RTM REST API to stream video from remote device to OpenRTM platform using HTTP protocol. Component exposes POST method named 'images' that you can use send jpeg image encoded as 64 bit string.

Sample request representation:

	application/json 

	{
		"data": "/9j/4AAQSkZJRgABAQAAAQABAAD/2wBDAAgGBgcGBQgHBwcJCQgKDBQNDAsLDBkSEw8UHRofHh0aHBwgJC4nICIsIxwcKDcpLDAxNDQ0Hyc5PTgyPC4zNDL/2wBDAQkJCQwLDBgNDRgyIRwhMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjL/wAARCACwAJADASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD5/ooooAKKKKACiiigD//Z"
	}

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
<a href="https://itunes.apple.com/us/app/rtm-client/id1009085714?ls=1&mt=8"><img src="http://rachwal.github.io/RTM-REST-API/images/Download_on_the_App_Store_Badge_US-UK_135x40.svg" alt="RTM Client"/></a>     <a href="https://play.google.com/store/apps/details?id=jp.go.aist.rachwal.rtmclient"><img alt="Get it on Google Play" src="https://developer.android.com/images/brand/en_generic_rgb_wo_45.png"/></a>     <a href="https://www.microsoft.com/store/apps/9NBLGGH1RK7G"><img src="https://cmsresources.windowsphone.com/devcenter/en-us/legacy_v1/img/badgegenerator/English_wstore_black_258x67.png" alt="Download from Windows Store" /></a>

License
---------------
This code is released under the MIT license. Any code contributions you make must be made under the same license.
