using PetShop.Core.DomainService.Filtering;
using PetShop.Core.Entity;
using System.Collections.Generic;
using Type = PetShop.Core.Entity.Type;

namespace PetShop.Core.DomainService
{
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadPetsFiltered(Filter filter);
        List<Pet> ReadPets();
        List<Pet> ReadPetByType(Type type);
        Pet CreatePet(Pet pet);
        bool DeletePet(int id);
        Pet UpdatePet(Pet pet);
        Pet ReadPetById(int id);
    }
}
