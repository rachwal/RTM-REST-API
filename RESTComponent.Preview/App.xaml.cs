using System.Windows;

namespace RESTComponent.Preview
{
     public partial class App : Application
    {
         protected override void OnStartup(StartupEventArgs e)
         {
             base.OnStartup(e);
             var bootstrapper = new PreviewBootstrapper();
             bootstrapper.Run();
         }
     }
}
