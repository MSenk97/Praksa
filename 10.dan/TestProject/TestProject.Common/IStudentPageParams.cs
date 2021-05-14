using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Common
{
    public interface IStudentPageModel
    {
        int DataPerPage { get; set; }
        int Page { get; set; }
    }
}
