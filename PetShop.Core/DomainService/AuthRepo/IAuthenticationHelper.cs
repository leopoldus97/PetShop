using PetShop.Core.Entity.AuthModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService.AuthRepo
{
    public interface IAuthenticationHelper
    {
        string GenerateToken(User user);
    }
}
