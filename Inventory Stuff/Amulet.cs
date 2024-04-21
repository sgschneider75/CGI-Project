namespace cgiComp
{
    public class Amulet
    {
        public string name { get; set; }

        public string bonus { get; set; }

        public Amulet(string name, string bonus){
            this.name = name;
            this.bonus = bonus;
        }

        public void WriteStats(){
            System.Console.WriteLine($"The {name} Amulet  ");
            InventoryHandler.WriteBonus(bonus);
        }
    }
}