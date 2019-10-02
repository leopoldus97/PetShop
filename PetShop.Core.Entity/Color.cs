using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entity
{
    public class Color
    {
        public int ID { get; set; }
        public string Colour { get; set; }
        public List<PetColor> PetColor { get; set; }
    }
}
