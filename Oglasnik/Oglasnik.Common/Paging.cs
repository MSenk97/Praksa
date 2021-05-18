using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Common
{
    public class Paging : IPaging
    {
        public int Page { get; set; }
        public int DataPerPage { get; set; }
    }
}
