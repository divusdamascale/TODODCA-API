using Microsoft.AspNetCore.Mvc;
using ToDoList.API.Domain.DTOs;
using ToDoList.API.Repositories.Interfaces;
using ToDoList.API.Services.Interfaces;
using ToDoList.API.Views.DTOs;
using ToDoList.API.Views.Models;
using Microsoft.AspNetCore.Mvc;


namespace ToDoList.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<string> LoginAsync(LoginDTO login)
        {
            var user = await _userRepository.GetUserByUsernameAsync(login.Username);

            if (user == null)
            {
                throw new Exception("Userul nu exista");
            }

            if (BCrypt.Net.BCrypt.Verify(login.Password, user.Pass))
            {
                //jwt
                return "Autentificare reușită";
            }

            return null;
        }

        public async Task<ActionResult<int>> RegisterAsync(RegisterDTO register)
        {

            if (await _userRepository.ExistsByEmail(register.Email) || await _userRepository.ExistsByUsername(register.Username))
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

            return user.UserId;
        }
    }
}
