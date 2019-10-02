using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Impl
{
    public class OwnerService : IOwnerService
    {
        IOwnerRepository _ownRepo;
        public OwnerService(IOwnerRepository ownRepo)
        {
            this._ownRepo = ownRepo;
        }

        public Owner AddOwner(Owner owner)
        {
            if (owner.FirstName == null || owner.LastName == null)
                throw new NullReferenceException("You can't create an owner without a full name!");
            else if (owner.ID == 0 || _ownRepo.ReadOwnerById(owner.ID) == null)
                throw new NullReferenceException("There's no such owner in the database!");
            return _ownRepo.CreateOwner(owner);
        }

        public List<Owner> GetOwners()
        {
            return _ownRepo.ReadOwners().ToList();
        }

        public bool RemoveOwner(int id)
        {
            return _ownRepo.DeleteOwner(id);
        }

        public Owner UpdateOwner(Owner owner)
        {
            if (owner.FirstName == null || owner.LastName == null)
                throw new NullReferenceException("You can't update the owner without his/her full name!");
            else if (owner.ID == 0)
                throw new NullReferenceException("The owner must have an id which is bigger than 0!");
            return _ownRepo.UpdateOwner(owner);
        }

        public Owner GetOwnerById(int id)
        {
            if (id < 1)
                throw new Exception("Id must be higher than 0!");
            return _ownRepo.ReadOwnerById(id);
        }
    }
}
