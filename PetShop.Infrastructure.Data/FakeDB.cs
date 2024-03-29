﻿using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Infrastructure.Data
{
    public static class FakeDB
    {
        static IEnumerable<Pet> PetList = new List<Pet>();
        static IEnumerable<Owner> OwnerList = new List<Owner>();

        public static IEnumerable<Owner> InitOwner()
        {
            List<Owner> owners = OwnerList.ToList();
            owners.Add(new Owner() { ID = 1, FirstName = "Michael", LastName = "Smith" });
            owners.Add(new Owner() { ID = 2, FirstName = "James", LastName = "Smith", Address = "Rolfsgade 22", Email = "james.smith@gmail.com", PhoneNumber = "50505040" });
            owners.Add(new Owner() { ID = 3, FirstName = "Jerry", LastName = "Watts", Address = "Baldursgade 77", Email = "jerry.watts@hotmail.com", PhoneNumber = "12225539" });
            owners.Add(new Owner() { ID = 4, FirstName = "Bill", LastName = "Bush", Address = "Julandsgade 32", Email = "bill.bush@yahoo.com", PhoneNumber = "40607080" });
            owners.Add(new Owner() { ID = 5, FirstName = "Keanu", LastName = "Reeves" });
            owners.Add(new Owner() { ID = 6, FirstName = "Edward", LastName = "Johnson" });
            return owners;
        }

        public static IEnumerable<Pet> InitData()
        {
            List<Owner> owners = InitOwner().ToList();
            List<Pet> pets = PetList.ToList();
            pets.Add(new Pet() { ID = 1, Name = "Frici", Type = Core.Entity.Type.CAT, BirthDate = new DateTime(2014, 03, 22), SoldDate = new DateTime(2018, 04, 05), Color = "white", /*PreviousOwner = owners.ElementAt(0),*/ Price = 608 });
            pets.Add(new Pet() { ID = 2, Name = "Rex", Type = Core.Entity.Type.DOG, BirthDate = new DateTime(2013, 04, 21), SoldDate = new DateTime(2019, 12, 23), Color = "black and brown", /*PreviousOwner = owners.ElementAt(1),*/ Price = 1353 });
            pets.Add(new Pet() { ID = 3, Name = "Snowball", Type = Core.Entity.Type.HAMSTER, BirthDate = new DateTime(2018, 07, 30), SoldDate = new DateTime(2017, 03, 21), Color = "white", /*PreviousOwner = owners.ElementAt(2),*/ Price = 702 });
            pets.Add(new Pet() { ID = 4, Name = "Slittery Slitters", Type = Core.Entity.Type.SNAKE, BirthDate = new DateTime(2016, 06, 06), SoldDate = new DateTime(2019, 04, 22), Color = "greenish", /*PreviousOwner = owners.ElementAt(3),*/ Price = 1023 });
            pets.Add(new Pet() { ID = 5, Name = "Pattu", Type = Core.Entity.Type.PARROT, BirthDate = new DateTime(2017, 03, 27), SoldDate = new DateTime(2019, 05, 16), Color = "rainbow", /*PreviousOwner = owners.ElementAt(4),*/ Price = 987});
            pets.Add(new Pet() { ID = 6, Name = "G-Force", Type = Core.Entity.Type.HAMSTER, BirthDate = new DateTime(2017, 12, 08), SoldDate = new DateTime(2019, 08, 15), Color = "ginger", /*PreviousOwner = owners.ElementAt(5),*/ Price = 254});
            
            return pets;
        }
    }
}
