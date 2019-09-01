using PetShop.Core.Entity;
using System.Collections.Generic;
using Type = PetShop.Core.Entity.Type;

namespace PetShop.Core.ApplicationService
{
    public interface IPetService
    {
        List<Pet> GetPets();
        List<Pet> GetPetByType(Type type);
        Pet AddPet(Pet pet);
        bool RemovePet(int id);
        Pet UpdatePet(Pet pet);
        List<Pet> SortListOfPets(int selector);
        List<Pet> TopFiveCheapest();

    }
}
