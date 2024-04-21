namespace cgiComp
{
    public class Trinket
    {
        public string name { get; set; }

        public string bonus { get; set; }

        public Trinket(string name, string bonus){
            this.name = name;
            this.bonus = bonus;
        }

        public void WriteStats(){
            System.Console.WriteLine($"The {name}  ");
            InventoryHandler.WriteBonus(bonus);
        }
    }
}