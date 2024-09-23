using InterfaceView_ViewModel;
using System.Windows;
using Test_MVVM.Services;
using Test_MVVM.Views;

public class WindowService : IWindowService
{
    public WindowService() {
    }

    public void ShowAddUserWindow(IUserService userService, object mainViewModel)
    {
        AddUser addUserWin = new(userService, mainViewModel)
        {
            Owner = Application.Current.MainWindow,
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };
        addUserWin.Show();
    }
}
