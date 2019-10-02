using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService.Filtering
{
    public enum Sorting { Default, Name, BirthDate, SoldDate, Price }
    public enum Ordering { Default, ASC, DESC }
    public class Filter
    {
        public int CurrentPage { get; set; }
        public int ItemsPrPage { get; set; }
        public Sorting SortBy { get; set; }
        public Ordering OrderBy { get; set; }
    }
}
