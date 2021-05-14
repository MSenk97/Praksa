using System;

namespace TestProject.Common
{
    public class StudentFilterParams : IStudentFilterParams
    {
        public string Ime { get; set; }
        public int FakultetID { get; set; }
    }
}