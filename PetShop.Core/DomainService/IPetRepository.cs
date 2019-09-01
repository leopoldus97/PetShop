﻿using PetShop.Core.Entity;
using System.Collections.Generic;
using Type = PetShop.Core.Entity.Type;

namespace PetShop.Core.DomainService
{
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadPets();
        List<Pet> ReadPetByType(Type type);
        Pet CreatePet(Pet pet);
        bool DeletePet(int id);
        Pet UpdatePet(Pet pet);

        /*
         * IEnumerable<Owner> ReadOwners();
         * Owner ReadOwnerById(int id);
         * Owner CreateOwner(Owner owner);
         * bool DeleteOwner(Owner owner);
         * Owner UpdateOwner(Owner owner);
         */ 
    }
}