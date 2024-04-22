namespace cgiComp
{
    public class Ring
    {
        public string name { get; set; }

        public string bonus { get; set; }

        public Ring(string name, string bonus){
            this.name = name;
            this.bonus = bonus;
        }

        public void WriteStats(){
            InventoryHandler.WriteBonus(bonus, name, "");
        }
    }
}