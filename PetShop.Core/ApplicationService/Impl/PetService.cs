using System.Collections.Generic;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System.Linq;
using System;
using PetShop.Core.DomainService.Filtering;

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
                if (pet.Name == null || pet.Name == "")
                    throw new NullReferenceException("You can't create a pet without a name!");
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

        public Pet GetPetById(int id)
        {
            if (id < 1)
                throw new Exception("Id must be higher than 0!");
            return _petRepo.ReadPetById(id);
        }

        public List<Pet> GetPets()
        {
            return _petRepo.ReadPets();
        }

        public IEnumerable<Pet> GetPetsFiltered(Filter filter)
        {
            return _petRepo.ReadPetsFiltered(filter);
        }

        public List<Pet> TopFiveCheapest()
        {
            return GetPets().OrderBy(pet => pet.Price).Take(5).ToList();
        }

        public Pet UpdatePet(Pet pet)
        {
            if (pet.Name == null || pet.Name == "")
                throw new NullReferenceException("The name is missing!");
            else if (pet.ID == 0)
                throw new NullReferenceException("The pet must have an id which is bigger than 0!");
            else if (pet.Price == 0)
                throw new NullReferenceException("The price is missing!");
            return _petRepo.UpdatePet(pet);
        }
    }
}
