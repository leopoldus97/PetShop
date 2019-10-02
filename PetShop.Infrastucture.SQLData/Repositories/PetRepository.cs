using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.DomainService.Filtering;
using PetShop.Core.Entity;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Infrastucture.SQLData.Repositories
{
    public class PetRepository : IPetRepository
    {
        public PetShopContext _ctx;

        public PetRepository(PetShopContext context)
        {
            _ctx = context;
        }

        public Pet CreatePet(Pet pet)
        {
            _ctx.Add(pet);
            _ctx.SaveChanges();
            return pet;
        }

        public bool DeletePet(int id)
        {
            var entityEntry = _ctx.Remove(new Pet() {ID = id});
            _ctx.SaveChanges();
            if (entityEntry == null)
                return false;
            else
                return true;
        }

        public Pet ReadPetById(int id)
        {
            //return _ctx.Pets.FirstOrDefault(pet => pet.ID == id);
            return _ctx.Pets.Where(o => o.ID == id).Include(p => p.PreviousOwner).FirstOrDefault();
        }

        public List<Pet> ReadPetByType(Type type)
        {
            return _ctx.Pets.Where(pet => pet.Type == type).ToList();
        }

        public List<Pet> ReadPets()
        {
            return _ctx.Pets.Include(p => p.PreviousOwner).ToList();
        }

        public Pet UpdatePet(Pet pet)
        {
            var entityEntry = _ctx.Update(pet);
            _ctx.SaveChanges();
            return entityEntry.Entity;
        }

        private IEnumerable<Pet> SortBy(IEnumerable<Pet> pets, Sorting sort)
        {
            IEnumerable<Pet> sortedList = null;
            switch (sort)
            {
                case Sorting.Name:
                    sortedList = pets.OrderBy(pet => pet.Name);
                    break;
                case Sorting.BirthDate:
                    sortedList = pets.OrderBy(pet => pet.BirthDate);
                    break;
                case Sorting.SoldDate:
                    sortedList = pets.OrderBy(pet => pet.SoldDate);
                    break;
                case Sorting.Color:
                    sortedList = pets.OrderBy(pet => pet.Color);
                    break;
                case Sorting.Price:
                    sortedList = pets.OrderBy(pet => pet.Price);
                    break;
                default:
                    return pets;
            }
            return sortedList;
        }

        private IEnumerable<Pet> OrderBy(IEnumerable<Pet> pets, Ordering order)
        {
            IEnumerable<Pet> orderedList = null;
            switch (order)
            {
                case Ordering.ASC:
                    orderedList = pets;
                    break;
                case Ordering.DESC:
                    orderedList = pets.Reverse();
                    break;
                default:
                    return pets;
            }
            return orderedList;
        }

        public IEnumerable<Pet> ReadPetsFiltered(Filter filter)

        {

            //Create a Filtered List

            var filteredList = new List<Pet>();



            //If there is a Filter then filter the list and set Count

            if (filter != null && filter.ItemsPrPage > 0 && filter.CurrentPage > 0)

            {

                filteredList = _ctx.Pets

                    .Include(c => c.PreviousOwner)

                    .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)

                    .Take(filter.ItemsPrPage).ToList();

                //filteredList.Count = _ctx.Pets.Count();

            }
            else
            {
                //Else just return the full list and get the count from the list (to save a SQL call)

                filteredList = _ctx.Pets

                    .Include(c => c.PreviousOwner).ToList();

                //filteredList.Count = filteredList.List.Count();

                return filteredList;
            }

            if (filter.SortBy > 0)
            {
                filteredList = SortBy(filteredList, filter.SortBy).ToList();
            }

            if (filter.OrderBy > 0)
            {
                filteredList = OrderBy(filteredList, filter.OrderBy).ToList();
            }

            return filteredList;
        }
    }
}
