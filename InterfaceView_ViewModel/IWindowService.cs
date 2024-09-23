
using Test_MVVM.Services;

namespace InterfaceView_ViewModel
{
    public interface IWindowService
    {
        void ShowAddUserWindow(IUserService _userService, object mainViewModel);
    }

}
