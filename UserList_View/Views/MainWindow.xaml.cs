using InterfaceView_ViewModel;
using System.Windows;
using System.Windows.Controls;
using Test_MVVM.Models;
using Test_MVVM.ViewModel;

namespace Test_MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'initialisation : {ex.Message}");
            }
            

            try
            {
                IWindowService windowService = new WindowService();
                MainViewModel mainViewModel = new MainViewModel(windowService);
                this.DataContext = mainViewModel;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'initialisation : {ex.Message}");
            }
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UserList.Items.Filter = FilterMethod;
        }

        private bool FilterMethod(object e)
        {
            var user = (User)e;
            return user.Name.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase);
        }
    }
}