using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _4SwaggerAPI.Domain;
using _4SwaggerAPI.Services.Abstract;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace _4SwaggerAPI.Services.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<List<User>> GetAll()
        {
            return await _userDal.GetAll();
        }

        public async Task<User> GetById(int id)
        {
            return await _userDal.Get(u=>u.Id == id);
        }

        public async Task<User> Add(User user)
        {
            return await _userDal.Add(user);
        }

        public async Task<User> Delete(User user)
        {
            return await _userDal.Delete(user);
        }

        public async Task<User> Update(User user)
        {
            return await _userDal.Update(user);
        }
    }
}
