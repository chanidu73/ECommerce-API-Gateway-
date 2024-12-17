using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;
using UserService.Repositories;
using BCrypt.Net;
namespace UserService.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository repository)
        {
            _userRepository = repository;
        } 
        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<UserModel> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }

        public async Task<UserModel> GetUserByUsernameAsync(string username)
        {
            return await _userRepository.GetByUsernameAsync(username);
        }

        public async Task<UserModel> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }

        public async Task RegisterUserAsync(RegisterModel registerModel)
        {
            if (await _userRepository.GetByUsernameAsync(registerModel.Username) != null)
                throw new Exception("Username already exists.");
            if (await _userRepository.GetByEmailAsync(registerModel.Email) != null)
                throw new Exception("Email already exists.");

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerModel.Password);

            var newUser = new UserModel
            {
                Username = registerModel.Username,
                Email = registerModel.Email,
                PasswordHash = hashedPassword,
                Role = registerModel.Role ?? "Customer",
                CreatedDate = DateTime.UtcNow
            };

            await _userRepository.AddAsync(newUser);
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteAsync(userId);        }
    }
}