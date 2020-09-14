using Caliburn.Micro;
using SensorMonitorWPFApp.ViewModels;
using System.Windows;

namespace SensorMonitorWPFApp
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
    }
}
