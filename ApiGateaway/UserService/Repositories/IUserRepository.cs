using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Repositories
{
    public interface IUserRepository:IRepository<UserModel>
    {
        Task<UserModel> GetByUsernameAsync(string username);
        Task<UserModel> GetByEmailAsync(string email);
    }
}