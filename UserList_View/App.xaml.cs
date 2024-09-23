using InterfaceView_ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;
using Test_MVVM;
using Test_MVVM.ViewModel;
using Unity;

namespace UserList_View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Crée manuellement l'instance du service
            IWindowService windowService = new WindowService();

            // Crée le ViewModel et passe le service en paramètre
            MainViewModel viewModel = new(windowService);

            // Crée la fenêtre principale et assigne le ViewModel comme DataContext
            //MainWindow mainWindow = new()
            //{
            //    DataContext = viewModel
            //};

            //mainWindow.Show();
        }
    }


}
