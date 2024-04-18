namespace cgiComp
{
    public class Blessing
    {
        private string name { get; set; }

        private string bonus { get; set; }

        public Blessing(string name, string bonus){
            this.name = name;
            this.bonus = bonus;
        }
        
    }
}