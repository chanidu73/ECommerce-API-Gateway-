using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.Data
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options):base(options)
        {}
        public DbSet<AuthModel> Auths  {get;set; }
        public DbSet<LoginModel>Logins { get;set; }
        public DbSet<UserModel>Users { get;set; }
        public DbSet<RegisterModel>Registers { get;set; }
    }
}