﻿using MnMFiber.Core.Models;
using MnMFiber.Core.Repositories;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MnMFiber.Services
{
    public class UserService : BaseService, IUserService
    {
        public async Task<CustomResponse> UpdatePasswordAsync(UserAccount user)
        {
            var response = await PostAndReadAsStringAsync("Account/UpdatePassword", false
                , CreateInput("LoginId", user.UserName)
                , CreateInput("Password", user.Password)
                , CreateInput("ConfirmPassword", user.ConfirmPassword)
                , CreateInput("OldPassword", user.OldPassword));

            return JsonConvert.DeserializeObject<CustomResponse>(response);
        }

        public async Task<CustomResponse> VerifyLoginAsync(UserAccount user)
        {
            var response = await PostAndReadAsStringAsync("Account", false
                , CreateInput("UserName", user.UserName)
                , CreateInput("Password", user.Password));

            return JsonConvert.DeserializeObject<CustomResponse>(response);
        }
    }
}
