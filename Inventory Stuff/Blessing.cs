namespace cgiComp
{
    public class Blessing
    {
        public string name { get; set; }

        public string bonus { get; set; }

        public Blessing(string name, string bonus){
            this.name = name;
            this.bonus = bonus;
        }
        
        public void WriteStats(){
            InventoryHandler.WriteBonus(bonus, name, "blessing");
        }
    }
}