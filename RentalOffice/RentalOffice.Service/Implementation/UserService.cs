using System;
using System.Linq;
using RentalOffice.Data;
using RentalOffice.Data.Entities;
using RentalOffice.Model;

namespace RentalOffice.Service.Implementation
{
    internal class UserService : IUserService
    {
        private RentalOfficeContext context = new RentalOfficeContext();

        public IQueryable<UserViewModel> GetAllUsers()
        {
            return context.Users.Select(u => new UserViewModel
            {
                UserId = u.UserId,
                Login = u.Login,
                Password = u.Password,
                Name = u.Name,
                Surname = u.Surname,
                Email = u.Email,
                Role = (int)u.Role,
                Phone = u.Phone
            });
        }

        public UserViewModel GetUserByLoginPassword(string log, string pass)
        {
            return context.Users.Where(u => u.Login == log && u.Password == pass)
                .Select(u => new UserViewModel
                {
                    UserId = u.UserId,
                    Login = u.Login,
                    Password = u.Password,
                    Name = u.Name,
                    Surname = u.Surname,
                    Email = u.Email,
                    Role = (int)u.Role,
                    Phone = u.Phone
                }).SingleOrDefault();
        }

        public UserViewModel GetUserByLogin(string log)
        {
            return context.Users.Where(u => u.Login == log)
                .Select(u => new UserViewModel
                {
                    UserId = u.UserId,
                    Login = u.Login,
                    Password = u.Password,
                    Name = u.Name,
                    Surname = u.Surname,
                    Email = u.Email,
                    Role = (int)u.Role,
                    Phone = u.Phone
                }).SingleOrDefault();
        }

        public UserViewModel GetUser(int id)
        {
            return context.Users.Where(u => u.UserId == id)
                 .Select(u => new UserViewModel
                 {
                     UserId = u.UserId,
                     Name = u.Name,
                     Surname = u.Surname,                 
                     Login = u.Login,
                     Password = u.Password,
                     Email = u.Email,
                     Role = (int)u.Role,
                     Phone = u.Phone
                 }).SingleOrDefault();
        }

        public void CreateUser(UserRegistrViewModel model)
        {
            var newUser = new User
           {
                Login = model.Login,
                Password = model.Password,
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                Phone = model.Phone,
                Role = RentalOffice.Data.Entities.Roles.Customer
            };
            context.Users.Add(newUser);
            context.SaveChanges();
        }

        public void CreateUserByAdmin(UserViewModel model)
        {
            var newUser = new User
            {
                Login = model.Login,
                Password = model.Password,
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                Phone = model.Phone,
                Role =(Roles) model.Role
            };
            context.Users.Add(newUser);
            context.SaveChanges();
        }

        public void UpdateUser(UserViewModel model)
        {
            var user = context.Users.Find(model.UserId);

            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Password = model.Password;
            user.Login = model.Login;
            user.Email = model.Email;
            user.Phone = model.Phone;
            user.Role = (Roles)model.Role;

            context.SaveChanges();
        }
    }
}
