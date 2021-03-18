using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _4SwaggerAPI.Domain;
using Microsoft.AspNetCore.Mvc;

namespace _4SwaggerAPI.Services.Abstract
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User> GetById(int id);

        Task<User> Add(User user);
        Task<User> Delete(User user);
        Task<User> Update(User user);
    }
}
