﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService.Filtering
{
    public class FilteredList <T>
    {
        public IEnumerable<T> List { get; set; }
        public int Count { get; set; }
    }
}
