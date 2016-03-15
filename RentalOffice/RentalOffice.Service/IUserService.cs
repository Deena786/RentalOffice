using System;
using System.Linq;
using RentalOffice.Data.Entities;
using RentalOffice.Model;

namespace RentalOffice.Service
{
    public interface IUserService
    {
        IQueryable<UserViewModel> GetAllUsers();
        UserViewModel GetUserByLoginPassword(string log, string pass);
        UserViewModel GetUserByLogin(string log);
        UserViewModel GetUser(int id);
        void CreateUser(UserRegistrViewModel model);
        void UpdateUser(UserViewModel model);
        void CreateUserByAdmin(UserViewModel model);
    }
}
