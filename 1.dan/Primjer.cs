using System;

namespace oop
{

     class Student
     {
        public virtual string StatusStudenta()
        {
            return "Student";
        }

        private string name;
        private int age;
        private string city;
        private int id;

        public Student(Student Stud)
        {
            id = Stud.id;
            name = Stud.name;
            age = Stud.age;
            city = Stud.city;
        }

        public Student(int id, string name, int age, string city)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.city = city;
        }

        public class RedovanStudent : Student
        {
            public RedovanStudent(int id, string name, int age, string city) : base(id, name, age, city) { }
            
            public override string StatusStudenta()
            {
                return "Redovan student";             
            }
            

        }

        public class IzvanredanStudent : Student
        {
            public IzvanredanStudent(int id, string name, int age, string city) : base(id, name, age, city){}

            public override string StatusStudenta()
            {
                return "Izvanredan Student";      
            }
        }
        
            
        public string DetailsAge
        {
            get
            {
                return "The age of " + name + " is " + age.ToString() + ".";
            }
        }

        public string DetailsCity
        {
            get
            {
                return "The resident city of " + name + " is " + city + ".";
            }
        }

        public static void CopyConstructor()
        {
            Student Stud1 = new RedovanStudent(1, "Marko", 23, "Osijek");
            Student Stud2 = new Student(Stud1);
            Student Stud3 = new RedovanStudent(3, "Ante", 22, "Ilok");
            Student Stud4 = new IzvanredanStudent(4, "Ivan Fran", 21, "Varaždin");
            Console.WriteLine(Stud2.DetailsAge + " " + Stud1.StatusStudenta());
            Console.WriteLine(Stud3.DetailsCity + " " + Stud3.StatusStudenta());
            Console.WriteLine(Stud4.DetailsAge + " " + Stud4.StatusStudenta());
        }
        public static void Main(string[] args){
            CopyConstructor();
        }
    }
    
}