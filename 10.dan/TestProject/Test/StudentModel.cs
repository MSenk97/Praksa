using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Models
{
    public class Student
    {
        public int StudentID;
        public string Ime;
        public int FakultetID;
        public Student(int studentID, string Ime, int FakultetID)
        {
            this.StudentID = studentID;
            this.Ime = Ime;
            this.FakultetID = FakultetID;
        }

        public Student() { }
    }
}