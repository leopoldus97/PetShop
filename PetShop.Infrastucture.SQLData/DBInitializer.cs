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
                PreviousOwner = ctx.Owners.Where(o => o.ID == 1 || o.ID == 2).ToList(),
                Price = 1023
            }).Entity;
            Pet p2 = ctx.Pets.Add(new Pet() {
                ID = 2,
                Name = "Bamboo",
                Type = Core.Entity.Type.SNAKE,
                BirthDate = new DateTime(2017, 08, 05),
                SoldDate = new DateTime(2019, 01, 14),
                PreviousOwner = ctx.Owners.Where(o => o.ID == 3).ToList(),
                Price = 1233
            }).Entity;
            
            Pet p3 = ctx.Pets.Add(new Pet() { ID = 3, Name = "Samson" }).Entity;
            Pet p4 = ctx.Pets.Add(new Pet() { ID = 4, Name = "Miguel" }).Entity;
            Pet p5 = ctx.Pets.Add(new Pet() { ID = 5, Name = "Rodrigo" }).Entity;
            Pet p6 = ctx.Pets.Add(new Pet() { ID = 6, Name = "Emanuel" }).Entity;
            Pet p7 = ctx.Pets.Add(new Pet() { ID = 7, Name = "Smurf" }).Entity;
            Pet p8 = ctx.Pets.Add(new Pet() { ID = 8, Name = "Griffon" }).Entity;
            Pet p9 = ctx.Pets.Add(new Pet() { ID = 9, Name = "Rex" }).Entity;
            Pet p10 = ctx.Pets.Add(new Pet() { ID = 10, Name = "Lassie" }).Entity;

            Pet p11 = ctx.Pets.Add(new Pet()
            {
                ID = 11,
                Name = "Snowball",
                Type = Core.Entity.Type.CAT,
                BirthDate = new DateTime(2012, 04, 25),
                SoldDate = new DateTime(2019, 01, 14),
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

            Color c1 = ctx.Colors.Add(new Color()
            {
                ID = 1,
                Colour = "Green"
            }).Entity;

            Color c2 = ctx.Colors.Add(new Color()
            {
                ID = 2,
                Colour = "Black"
            }).Entity;

            Color c3 = ctx.Colors.Add(new Color()
            {
                ID = 3,
                Colour = "Red"
            }).Entity;

            Color c4 = ctx.Colors.Add(new Color()
            {
                ID = 4,
                Colour = "White"
            }).Entity;

            PetColor pc1 = ctx.PetColors.Add(new PetColor()
            {
                Color = c1,
                Pet = p1
            }).Entity;

            PetColor pc2 = ctx.PetColors.Add(new PetColor()
            {
                Color = c2,
                Pet = p1
            }).Entity;

            PetColor pc3 = ctx.PetColors.Add(new PetColor()
            {
                Color = c1,
                Pet = p11
            }).Entity;

            PetColor pc4 = ctx.PetColors.Add(new PetColor()
            {
                Color = c3,
                Pet = p2
            }).Entity;

            PetColor pc5 = ctx.PetColors.Add(new PetColor()
            {
                Color = c4,
                Pet = p12
            }).Entity;

            PetColor pc6 = ctx.PetColors.Add(new PetColor()
            {
                Color = c3,
                Pet = p12
            }).Entity;

            ctx.SaveChanges();
        }
    }
}
