using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService
{
    public interface IOwnerRepository
    {
        
         IEnumerable<Owner> ReadOwners();
         Owner CreateOwner(Owner owner);
         bool DeleteOwner(int id);
         Owner UpdateOwner(Owner owner);
         Owner ReadOwnerById(int id);

    }
}
