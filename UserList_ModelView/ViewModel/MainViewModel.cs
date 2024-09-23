using InterfaceView_ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Test_MVVM.Commands;
using Test_MVVM.Models;
using Test_MVVM.Services;


namespace Test_MVVM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                NotifyPropertyChanged(nameof(Users));
            }
        }

        private readonly IWindowService _windowService;

        // Notify of the changes when changed
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private bool isUpdate = false;

        public ICommand ShowWindowCommand { get; }
        public ICommand DeleteUserCommand { get; }

        private IUserService _userService;

        public MainViewModel(IWindowService windowService)
        {
            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);

            DeleteUserCommand = new RelayCommand(DeleteUser, CanDeleteUser);

            _windowService = windowService;

            _userService = new UserService();
            LoadUsers();
        }

        // Load users from the service and populate the ObservableCollection
        private void LoadUsers()
        {
            Users = new ObservableCollection<User>(_userService.GetUsers());
        }

        // Method to refresh users after adding a new one
        public void RefreshUsers()
        {
            Users.Clear();
            foreach (var user in _userService.GetUsers())
            {
                Users.Add(user);
            }
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void ShowWindow(object obj)
        {
            _windowService.ShowAddUserWindow(_userService, this);
        }

        private User _selectedUser;
        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                NotifyPropertyChanged(nameof(SelectedUser));
            }
        }

        private void DeleteUser(object obj)
        {
            _userService.DeleteUser(SelectedUser);
            Users.Remove(SelectedUser);
            SelectedUser = null;
        }
        private bool CanDeleteUser(object obj)
        {
            return true;
        }
    }
}
