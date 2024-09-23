using InterfaceView_ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Test_MVVM.Views;

public class WindowService : IWindowService
{
    public void ShowAddUserWindow()
    {
        AddUser addUserWin = new()
        {
            Owner = Application.Current.MainWindow,
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };
        addUserWin.Show();
    }
}
