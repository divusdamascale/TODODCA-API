using Microsoft.AspNetCore.Mvc;
using ToDoList.API.Domain.DTOs;
using ToDoList.API.Repositories.Interfaces;
using ToDoList.API.Services.Interfaces;
using ToDoList.API.Views.DTOs;
using ToDoList.API.Views.Models;
using Microsoft.AspNetCore.Mvc;
using ToDoList.API.Utils;
using ToDoList.API.Utils.Interfaces;
using ToDoList.API.Domain.Entity;

namespace ToDoList.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJWTUtils _jwt;

        public AuthService(IUserRepository userRepository,IJWTUtils jwt)
        {
            _userRepository = userRepository;
            _jwt = jwt;
        }
        public async Task<LoggedUser> LoginAsync(LoginDTO login)
        {
            var user = await _userRepository.GetUserByUsernameAsync(login.Username);

            if (user == null)
            {
                throw new Exception("Userul nu exista");
            }

            if(BCrypt.Net.BCrypt.Verify(login.Password, user.Pass))
            {

                LoggedUser loggedUser = new LoggedUser
                {
                    Email = user.Email,
                    Lists = user.Lists,
                    Profile = user.Profile,
                    Tags = user.Tags,
                    Token = _jwt.CreateToken(user),
                    UserId = user.UserId,
                    Username = user.Username
                };
                return loggedUser;
            }

            return null;
        }

        public async Task<RegisterDTO> RegisterAsync(RegisterDTO register)
        {
            try
            {
                if(await _userRepository.ExistsByEmail(register.Email) || await _userRepository.ExistsByUsername(register.Username))
                {

                    throw new Exception("Username sau Email exista deja");
                }


                var user = new User
                {
                    Username = register.Username,
                    Pass = BCrypt.Net.BCrypt.HashPassword(register.Password),
                    Email = register.Email
                };

                var profile = new Profile
                {
                    FirstName = register.FirstName,
                    LastName = register.LastName,
                    BirthDate = register.BirthDate,
                    RegisterDate = DateTime.Now
                };

                user.Profile = profile;
                await _userRepository.AddAsync(user);
                await _userRepository.SaveChangesAsync();

                return register;
            }catch(Exception ex)
            {
                throw new Exception("Eroare",ex);
            }     
        }
    }
}
