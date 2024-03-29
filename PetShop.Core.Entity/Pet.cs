﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entity
{
    public enum Type
    {
        CREATURE, DOG, CAT, SNAKE, HAMSTER, PARROT
    }

    public class Pet
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime SoldDate { get; set; }
        public List<PetColor> PetColor { get; set; }
        public List<Owner> PreviousOwner { get; set; }
        public double Price { get; set; }
    }
}
