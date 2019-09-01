using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System.Linq;

namespace PetShop.Core.ApplicationService.Impl
{
    public class PetService : IPetService
    {
        IPetRepository _petRepo;

        public PetService(IPetRepository petRepo)
        {
            this._petRepo = petRepo;
        }

        public Pet AddPet(Pet pet)
        {
            return _petRepo.CreatePet(pet);
        }

        public bool RemovePet(int id)
        {
            return _petRepo.DeletePet(id);
        }

        public List<Pet> GetPetByType(Entity.Type type)
        {
            return _petRepo.ReadPetByType(type);
        }

        public List<Pet> GetPets()
        {
            return _petRepo.ReadPets().ToList();
        }

        public List<Pet> SortListOfPets(int selector)
        {
            switch (selector)
            {
                case 1:
                   return GetPets().OrderBy(pet => pet.Name).ToList();
                case 2:
                    return GetPets().OrderBy(pet => pet.BirthDate).ToList();
                case 3:
                    return GetPets().OrderBy(pet => pet.SoldDate).ToList();
                case 4:
                    return GetPets().OrderBy(pet => pet.Color).ToList();
                case 5:
                    return GetPets().OrderBy(pet => pet.Price).ToList();
                default:
                    return null;
            }
        }

        public List<Pet> TopFiveCheapest()
        {
            return GetPets().OrderBy(pet => pet.Price).Take(5).ToList();
        }

        public Pet UpdatePet(Pet pet)
        {
            return _petRepo.UpdatePet(pet);
        }
    }
}
