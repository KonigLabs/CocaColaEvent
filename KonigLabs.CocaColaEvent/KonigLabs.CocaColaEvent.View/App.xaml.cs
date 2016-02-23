using KonigLabs.CocaColaEvent.CommonViewModels.Ninject;
using KonigLabs.CocaColaEvent.ViewModel.Ninject;
using KonigLabs.CocaColaEvent.ViewModel.ViewModels;
using Ninject;
using System.Windows;

namespace KonigLabs.CocaColaEvent.View
{
       
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainViewModel _mainViewModel;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DispatcherUnhandledException += (s, ev) =>
            {
                NLog.LogManager.GetCurrentClassLogger().Error(ev.Exception);
            };
            InitApp();
        }

        public void InitApp()
        {
            //инициализация Ninject
            var kernel = NinjectBootstrapper.GetKernel(new CommonViewModels.Ninject.NinjectBaseModule(),new NinjectMainModule());
            _mainViewModel = kernel.Get<MainViewModel>();
            MainWindow = new MainWindow() { DataContext = _mainViewModel };
            MainWindow.Closed += (s, e) =>
            {
                _mainViewModel.Dispose();
            };
            MainWindow.Show();
        }
    }
}
