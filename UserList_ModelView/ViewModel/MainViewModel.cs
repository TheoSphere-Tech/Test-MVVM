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
        public List<User> Users { get; set; }

        private readonly IWindowService _windowService;

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private bool isUpdate = false;

        public ICommand ShowWindowCommand { get; }

        public MainViewModel(IWindowService windowService)
        {
            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);

            _windowService = windowService;

            IUserService userService = new UserService();
            Users = userService.GetUsers();
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void ShowWindow(object obj)
        {
            _windowService.ShowAddUserWindow();
        }
    }
}
