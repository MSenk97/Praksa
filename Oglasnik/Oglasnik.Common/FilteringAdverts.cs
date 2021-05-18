using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Common
{

    public class FilteringAdverts : IFilteringAdverts
    {
        public int CategoryID { get; set; }
        public string Title { get; set; }

        public int PriceMin { get; set; }
        public int PriceMax { get; set; }

        public string Condition { get; set; }
        public string HowToFilter()
        {
            string filtering = "";
            int counter = 0;
            if (CategoryID > 0)
            {
                filtering += " WHERE CategoryID = " + CategoryID;
                counter += 1;
            }
            if (Title != null)
            {
                if (counter > 0)
                {
                    filtering += " AND Title like '%" + Title + "%'";

                }
                else
                {
                    filtering += " WHERE Title like '%" + Title + "%'";
                    counter += 1;
                }
                
            }
            if ((PriceMin != 0) && (PriceMax != 0))
            {
                if (counter > 0)
                {
                    filtering += " AND Price BETWEEN " + PriceMin + " AND " + PriceMax;
                }
                else
                {
                    filtering += " WHERE Price BETWEEN " + PriceMin + " AND " + PriceMax;
                    counter += 1;
                }
                
            }
            if (Condition != null)
            {
                if (counter > 0)
                {
                    filtering += " AND Condition LIKE '%" + Condition + "%'";
                }
                else
                {
                    filtering += " WHERE Condition LIKE '%" + Condition + "%'";
                }
            }
            return filtering;
        }
    }
}
