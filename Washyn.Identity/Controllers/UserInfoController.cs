using System;
using Acme.Identity.Others;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Acme.Identity.Controllers
{
    [AllowAnonymous]
    [Route("api/abp/application-user-configuration")]
    [ApiController]
    public class UserInfoController : Controller
    {
        private readonly IExtraPropCurrentUser _currentUser;

        public UserInfoController(IExtraPropCurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        [HttpGet]
        public CustomCurrentUserDto Get()
        {
            return new CustomCurrentUserDto()
            {
                UserId = _currentUser.UserId,
                Email = _currentUser.Email,
                Roles = _currentUser.Roles,
                Name = _currentUser.Name,
                IsAuthenticated = _currentUser.IsAuthenticated,
                SurName = _currentUser.SurName,
                PhoneNumber = _currentUser.PhoneNumber,
                UserName = _currentUser.UserName,
            };
        }
    }

    [Serializable]
    public class CustomCurrentUserDto
    {
        public bool IsAuthenticated { get; set; }

        public int? UserId { get; set; }
        
        public string UserName { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }

        public string[] Roles { get; set; }
    }
}