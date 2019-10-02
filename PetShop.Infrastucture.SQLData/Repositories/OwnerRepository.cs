using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Infrastucture.SQLData.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        public PetShopContext _ctx;

        public OwnerRepository(PetShopContext ctx)
        {
            this._ctx = ctx;
        }

        public Owner CreateOwner(Owner owner)
        {
            _ctx.Add(owner);
            _ctx.SaveChanges();
            return owner;
        }

        public bool DeleteOwner(int id)
        {
            var entityEntry = _ctx.Remove(new Owner() { ID = id });
            _ctx.SaveChanges();
            if (entityEntry == null)
                return false;
            else
                return true;
        }

        public Owner ReadOwnerById(int id)
        {
            return _ctx.Owners.Include(o => o.Pet).FirstOrDefault(owner => owner.ID == id);
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return _ctx.Owners.ToList();
        }

        public Owner UpdateOwner(Owner owner)
        {
            var entityEntry = _ctx.Update(owner);
            _ctx.SaveChanges();
            return entityEntry.Entity;
        }
    }
}
