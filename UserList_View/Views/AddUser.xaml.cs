using System.Windows;
using Test_MVVM.ViewModel;

namespace Test_MVVM.Views
{
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            this.DataContext = addUserViewModel;
        }
    }
}
