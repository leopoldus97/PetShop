﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entity
{
    public class PetColor
    {
        public int PetId { get; set; }
        public Pet Pet { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
    }
}
