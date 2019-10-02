using PetShop.Core.DomainService;
using PetShop.Core.DomainService.Filtering;
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
            pet.ID = PetList.Max(p => p.ID)+1;
            PetList.Add(pet);
            return pet;
        }

        public bool DeletePet(int id)
        {
            //int numb = PetList.RemoveAll(x => x.ID == id);
            //bool isDeleted;
            //if (numb > 0)
            //    isDeleted = true;
            //else
            //    isDeleted = false;
            //return isDeleted;
            return PetList.Remove(ReadPetById(id));
        }

        public List<Pet> ReadPetByType(Core.Entity.Type type)
        {
            return PetList.Where(x => x.Type == type).ToList();
        }

        public IEnumerable<Pet> ReadPets()
        {
            //return PetList.Select(p => {
            //    if (p.PreviousOwner == null) return p;
            //   p.PreviousOwner = FakeDB.InitOwner().FirstOrDefault(o => o.ID == p.PreviousOwner.ID); return p;
            //});
            return null;
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

        public Pet ReadPetById(int id)
        {
                return PetList.FirstOrDefault(x => x.ID == id);
        }

        public FilteredList<Pet> ReadPetsFiltered(Filter filter)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Pet> IPetRepository.ReadPetsFiltered(Filter filter)
        {
            throw new System.NotImplementedException();
        }

        List<Pet> IPetRepository.ReadPets()
        {
            throw new System.NotImplementedException();
        }
    }
}
