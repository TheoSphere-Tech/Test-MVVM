using System.Windows;
using Test_MVVM.Services;
using Test_MVVM.ViewModel;

namespace Test_MVVM.Views
{
    public partial class AddUser : Window
    {
        public AddUser(IUserService _userService, object mainViewModel)
        {
            InitializeComponent();
            AddUserViewModel addUserViewModel = new(_userService, (MainViewModel) mainViewModel);
            this.DataContext = addUserViewModel;
        }
    }
}
