using System.Collections.Generic;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System.Linq;
using System;

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
            if (pet.Name.Equals(null))
                throw new NullReferenceException("You can't create a pet without a name!");
            else if (pet.ID == 0 || _petRepo.ReadPetById(pet.ID) == null)
                throw new NullReferenceException("There's no such pet in the database!");
            else if (pet.Price == 0)
                throw new NullReferenceException("You have to set a price!");
            return _petRepo.CreatePet(pet);
        }

        public bool RemovePet(int id)
        {
            if (!_petRepo.DeletePet(id))
            {
                throw new Exception("The pet hasn't been removed!");
            }
            return true;
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
            if (pet.Name.Equals(null))
                throw new NullReferenceException("The name is missing!");
            else if (pet.ID == 0)
                throw new NullReferenceException("The pet must have an id which is bigger than 0!");
            else if (pet.Price == 0)
                throw new NullReferenceException("The price is missing!");
            return _petRepo.UpdatePet(pet);
        }
    }
}
