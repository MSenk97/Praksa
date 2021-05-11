using FakultetInterface;

namespace MyModels
{ 
    public class Fakultet : IFakultet
    {
        public int FakultetID { get; set; }
        public string Ime { get; set; }
        public Fakultet(int FakultetID, string Ime)
        {
            this.FakultetID = FakultetID;
            this.Ime = Ime;
        }

        public Fakultet() { }
    }
}