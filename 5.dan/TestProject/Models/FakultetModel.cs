namespace MyModels
{
    public class Fakultet
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