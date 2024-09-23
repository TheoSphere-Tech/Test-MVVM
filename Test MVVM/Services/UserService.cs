using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_MVVM.Models;

namespace Test_MVVM.Services
{
    public class UserService : IUserService
    {
        public event Action<Models.User> UserAdded;

        public bool AddUser(Models.User user)
        {
            try
            {
                using (var context = new TestUserListContext())
                {
                    context.Add(user);
                    context.SaveChanges();
                    UserAdded?.Invoke(user);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteUser(Models.User user)
        {
            try
            {
                using (var context = new TestUserListContext())
                {
                    context.Remove(user);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Models.User> GetUsers()
        {
            try
            {
                using (var context = new TestUserListContext())
                {
                    return context.Users.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
