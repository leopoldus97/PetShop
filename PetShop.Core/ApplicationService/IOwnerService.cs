using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService
{
    public interface IOwnerService
    {
        List<Owner> GetOwners();
        Owner AddOwner(Owner owner);
        bool RemoveOwner(int id);
        Owner UpdateOwner(Owner owner);
        Owner GetOwnerById(int id);
    }
}
