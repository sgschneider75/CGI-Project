namespace cgiComp
{
    public class Weapon
    {
        public string name { get; set; }

        public int damage { get; set; }

        public string bonus { get; set; }

        public Weapon(string name, int damage, string bonus){
            this.name = name;
            this.damage = damage;
            this.bonus = bonus;
        }

        public void WriteStats(){
            System.Console.WriteLine($"The {name}  Damage: {damage}  ");
            InventoryHandler.WriteBonus(bonus);
        }
    }
}