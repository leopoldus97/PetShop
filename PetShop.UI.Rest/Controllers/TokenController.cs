using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.DomainService.AuthRepo;
using PetShop.Core.Entity.AuthModels;

namespace PetShop.UI.Rest.Controllers
{
    [Route("/token")]

    public class TokenController : Controller

    {

        private IUserRepository<User> repository;

        private IAuthenticationHelper authenticationHelper;



        public TokenController(IUserRepository<User> repos, IAuthenticationHelper authService)

        {

            repository = repos;

            authenticationHelper = authService;

        }





        [HttpPost]

        public IActionResult Login([FromBody]LoginInputModel model)

        {

            var user = repository.GetAll().FirstOrDefault(u => u.Username == model.Username);



            // check if username exists

            if (user == null)

                return Unauthorized();



            // check if password is correct

            if (!model.Password.Equals(user.Password))

                return Unauthorized();



            // Authentication successful

            return Ok(new

            {

                username = user.Username,

                token = authenticationHelper.GenerateToken(user)

            });

        }



    }
}