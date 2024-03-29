﻿using Microsoft.EntityFrameworkCore;
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
            return ReadPets().Where(o => o.ID == id).FirstOrDefault();
        }

        public List<Pet> ReadPetByType(Type type)
        {
            return ReadPets().Where(pet => pet.Type == type).ToList();
        }

        public List<Pet> ReadPets()
        {
            return _ctx.Pets.Include(p => p.PreviousOwner).Include(p => p.PetColor).ThenInclude(pc => pc.Color).ToList();
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
                case Sorting.Price:
                    sortedList = pets.OrderBy(pet => pet.Price);
                    break;
                default:
                    return pets;
            }
            return sortedList;
        }

        //private IEnumerable<Pet> FilterBy(IEnumerable<Pet> pets, Filter filter)
        //{
        //    IEnumerable<Pet> sortedList = pets;
        //    if (filter.FType < 1)
        //    {
        //        sortedList = sortedList.Where(pet => pet.Type == filter.FType);
        //    }
        //    if (filter.DuckCostume != null)
        //    {
        //        sortedList = sortedList.Where(duck => duck.DuckCostume.Equals(filter.DuckCostume));
        //    }
        //    if (filter.DuckPattern != null)
        //    {
        //        sortedList = sortedList.Where(duck => duck.DuckPattern.Equals(filter.DuckPattern));
        //    }
        //    if (filter.Size != DuckSize.DEFAULT)
        //    {
        //        sortedList = sortedList.Where(duck => duck.DuckSize.Equals(filter.Size));
        //    }
        //    if (filter.DuckGender != DuckGender.DEFAULT)
        //    {
        //        sortedList = sortedList.Where(duck => duck.DuckGender.Equals(filter.DuckGender));
        //    }
        //    return sortedList;
        //}

        private IEnumerable<Pet> OrderBy(IEnumerable<Pet> pets, Ordering order)
        {
            IEnumerable<Pet> orderedList;
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

            List<Pet> filteredList;



            //If there is a Filter then filter the list and set Count

            if (filter != null || filter.CurrentPage > 0)

            {
                if (filter.ItemsPrPage < 1)
                    filter.ItemsPrPage = 10;

                filteredList = ReadPets()

                    .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)

                    .Take(filter.ItemsPrPage).ToList();

                //filteredList.Count = _ctx.Pets.Count();

            }
            else
            {
                //Else just return the full list and get the count from the list (to save a SQL call)

                filteredList = ReadPets();

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
