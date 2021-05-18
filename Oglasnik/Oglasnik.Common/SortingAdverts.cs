using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Common
{
    public class SortingAdverts : ISortingAdverts
    {
        public string SortOrder { get; set; }
        public string SortBy { get; set; }

        public bool Sort()
        {
            if (SortBy == null && SortOrder == null)
            {
                SortBy = "Title";
                SortOrder = "asc";
            }
            switch (SortOrder)
            {
                case "asc":
                    break;
                case "desc":
                    break;
                default:
                    return false;
            }
            switch (SortBy)
            {
                case "Price":

                    break;
                default:
                    return false;
            }
            return true;
        }

        
    }
}
