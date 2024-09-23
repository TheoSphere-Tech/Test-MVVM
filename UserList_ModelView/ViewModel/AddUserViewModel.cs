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
    public class AddUserViewModel : INotifyPropertyChanged
    {
        public ICommand AddUserCommand { get; set; }

        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Surname { get; set; }

        public AddUserViewModel() {
            AddUserCommand = new RelayCommand(AddUser, CanAddUser);
        }

        private IUserService userService = new UserService();

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private bool isUpdate = false;

        private bool CanAddUser(object obj)
        {
            return true;
        }

        private void AddUser(object obj)
        {
            userService.AddUser(new User() { Name = Name, Email = Email, Surname = Surname });
            NotifyPropertyChanged("IsAddUser");
        }
    }
}
