using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        static List<Pet> PetList = FakeDB.InitData().ToList();
        public Pet CreatePet(Pet pet)
        {
            PetList.Add(pet);
            return pet;
        }

        public bool DeletePet(int id)
        {
            int numb = PetList.RemoveAll(x => x.ID == id);
            bool isDeleted;
            if (numb > 0)
                isDeleted = true;
            else
                isDeleted = false;
            return isDeleted;
        }

        public List<Pet> ReadPetByType(Core.Entity.Type type)
        {
            return PetList.Where(x => x.Type == type).ToList();
        }

        public IEnumerable<Pet> ReadPets()
        {
            return PetList;
        }

        public Pet UpdatePet(Pet pet)
        {
            foreach (Pet p in PetList)
            {
                if (pet.ID == p.ID)
                {
                    PetList.Remove(p);
                    PetList.Insert(p.ID-1, pet);
                    break;
                }
            }
            return pet;
        }
    }
}
