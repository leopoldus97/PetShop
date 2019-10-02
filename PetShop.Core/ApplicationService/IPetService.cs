using PetShop.Core.DomainService.Filtering;
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
        IEnumerable<Pet> GetPetsFiltered(Filter filter);
        List<Pet> TopFiveCheapest();
        Pet GetPetById(int id);
        List<Pet> GetPetsByPage(int id);

    }
}
