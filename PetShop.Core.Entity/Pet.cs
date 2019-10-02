using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entity
{
    public enum Type
    {
        DOG, CAT, SNAKE, HAMSTER, PARROT, CREATURE
    }

    public class Pet
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public List<Owner> PreviousOwner { get; set; }
        public double Price { get; set; }
    }
}
