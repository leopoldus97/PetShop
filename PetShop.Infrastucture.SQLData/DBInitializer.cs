using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastucture.SQLData
{
    public class DBInitializer
    {
        public static void Seed(PetShopContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            Pet p1 = ctx.Pets.Add(new Pet() {
                ID = 1,
                Name = "Frici",
                Type = Core.Entity.Type.CAT,
                BirthDate = new DateTime(2014, 03, 04),
                SoldDate = new DateTime(2015, 10, 11),
                Color = "Red",
                PreviousOwner = ctx.Owners.Where(o => o.ID == 1 || o.ID == 2).ToList(),
                Price = 1023
            }).Entity;
            Pet p2 = ctx.Pets.Add(new Pet() {
                ID = 2,
                Name = "Bamboo",
                Type = Core.Entity.Type.SNAKE,
                BirthDate = new DateTime(2017, 08, 05),
                SoldDate = new DateTime(2019, 01, 14),
                Color = "Green",
                PreviousOwner = ctx.Owners.Where(o => o.ID == 3).ToList(),
                Price = 1233
            }).Entity;
            
            Pet p3 = ctx.Pets.Add(new Pet() { ID = 3 }).Entity;
            Pet p4 = ctx.Pets.Add(new Pet() { ID = 4 }).Entity;
            Pet p5 = ctx.Pets.Add(new Pet() { ID = 5 }).Entity;
            Pet p6 = ctx.Pets.Add(new Pet() { ID = 6 }).Entity;
            Pet p7 = ctx.Pets.Add(new Pet() { ID = 7 }).Entity;
            Pet p8 = ctx.Pets.Add(new Pet() { ID = 8 }).Entity;
            Pet p9 = ctx.Pets.Add(new Pet() { ID = 9 }).Entity;
            Pet p10 = ctx.Pets.Add(new Pet() { ID = 10 }).Entity;

            Pet p11 = ctx.Pets.Add(new Pet()
            {
                ID = 11,
                Name = "Snowball",
                Type = Core.Entity.Type.CAT,
                BirthDate = new DateTime(2012, 04, 25),
                SoldDate = new DateTime(2019, 01, 14),
                Color = "White",
                PreviousOwner = ctx.Owners.Where(o => o.ID == 4).ToList(),
                Price = 1233
            }).Entity;
            Pet p12 = ctx.Pets.Add(new Pet()
            {
                ID = 12,
                Name = "Shadow",
                Type = Core.Entity.Type.HAMSTER,
                BirthDate = new DateTime(2017, 08, 05),
                SoldDate = new DateTime(2019, 01, 14),
                Color = "Black",
                PreviousOwner = ctx.Owners.Where(o => o.ID == 5).ToList(),
                Price = 1233
            }).Entity;


            Owner owner1 = ctx.Owners.Add(new Owner()
            {
                ID = 1,
                FirstName = "John",
                LastName = "Johnson",
                Address = "Skolegade 22",
                Email = "john.johnson@live.com",
                PhoneNumber = "4550668632",
                Pet = p1
            }).Entity;
            Owner owner2 = ctx.Owners.Add(new Owner()
            {
                ID = 2,
                FirstName = "David",
                LastName = "Davidson",
                Address = "Rolfsgade 55",
                Email = "david.david22@hotmail.com",
                PhoneNumber = "4540334455",
                Pet = p1
            }).Entity;
            Owner owner3 = ctx.Owners.Add(new Owner()
            {
                ID = 3,
                FirstName = "Daniel",
                LastName = "Johnson",
                Address = "Rolfsgade 25",
                Email = "daniel.johnson22@hotmail.com",
                PhoneNumber = "4540234455",
                Pet = p2
            }).Entity;
            Owner owner4 = ctx.Owners.Add(new Owner()
            {
                ID = 4,
                FirstName = "Michael",
                LastName = "Morrison",
                Address = "Skjoldsgade 35",
                Email = "michael.morrison2@hotmail.com",
                PhoneNumber = "4540334477",
                Pet = p11
            }).Entity;
            Owner owner5 = ctx.Owners.Add(new Owner()
            {
                ID = 5,
                FirstName = "Hugo",
                LastName = "Armani",
                Address = "Rolfsgade 15",
                Email = "hugo.armani@hotmail.com",
                PhoneNumber = "4540311455",
                Pet = p12
            }).Entity;

            ctx.SaveChanges();
        }
    }
}
