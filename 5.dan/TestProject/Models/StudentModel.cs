namespace StudentModel
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Ime { get; set; }
        public int FakultetID { get; set; }
        public Student(int studentID, string Ime, int FakultetID)
        {
            this.StudentID = studentID;
            this.Ime = Ime;
            this.FakultetID = FakultetID;
        }

        public Student() { }
    }
}