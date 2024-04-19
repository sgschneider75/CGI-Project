namespace cgiComp
{
    public class Ring
    {
        private string name { get; set; }

        private string bonus { get; set; }

        public Ring(string name, string bonus){
            this.name = name;
            this.bonus = bonus;
        }

        public void WriteStats(){
            System.Console.WriteLine($"The {name}  ");
            InventoryHandler.WriteBonus(bonus);
        }
    }
}