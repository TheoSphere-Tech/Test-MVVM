using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Test_MVVM.Commands;
using Test_MVVM.Models;
using Test_MVVM.Services;

namespace Test_MVVM.ViewModel
{
    public class AddUserViewModel
    {
        private IUserService _userService;
        private MainViewModel _mainViewModel;

        public ICommand AddUserCommand { get; set; }

        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Surname { get; set; }

        public AddUserViewModel(IUserService userService, MainViewModel mainViewModel) {
            _userService = userService;
            _mainViewModel = mainViewModel;
            AddUserCommand = new RelayCommand(AddUser, CanAddUser);
        }


        private bool CanAddUser(object obj)
        {
            return true;
        }

        private void AddUser(object obj)
        {
            _userService.AddUser(new User() { Name = Name, Email = Email, Surname = Surname });
            _mainViewModel.RefreshUsers();
        }
    }
}
