namespace cgiComp
{
    public class Potion
    {
        public string name { get; set; }

        private string bonus { get; set; }

        public int potionNumber { get; set; }

        public Potion(string name, string bonus){
            this.name = name;
            this.bonus = bonus;
            this.potionNumber = 0;
        }

        
    }
}