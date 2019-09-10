using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        static List<Owner> OwnerList = FakeDB.InitOwner().ToList();
        public Owner CreateOwner(Owner owner)
        {
            OwnerList.Add(owner);
            return owner;
        }

        public bool DeleteOwner(int id)
        {
            foreach (Owner owner in OwnerList)
            {
                if (owner.ID == id)
                {
                    return OwnerList.Remove(owner);
                }
            }
            return false;
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return OwnerList;
        }

        public Owner UpdateOwner(Owner owner)
        {
            foreach (Owner o in OwnerList)
            {
                if (owner.ID == o.ID)
                {
                    OwnerList.Remove(o);
                    OwnerList.Insert(o.ID - 1, owner);
                    break;
                }
            }
            return owner;
        }

        public Owner ReadOwnerById(int id)
        {
            return OwnerList.First(x => x.ID == id);
        }
    }
}
