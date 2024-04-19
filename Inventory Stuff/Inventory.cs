using System.Diagnostics.Contracts;

namespace cgiComp
{
    public class Inventory
    {

        private int coins { get; set; }

        private Weapon weapon{ get; set; }

        private Trinket trinket{ get; set; }

        private Amulet amulet{ get; set; }

        private Ring ring{ get; set; }

        private Blessing blessing{ get; set; }

        private Potion[] potions { get; set; }
        public Inventory(){
            this.coins = 0;
            this.weapon = new Weapon("none", 0, "none/none");
            this.trinket = new Trinket("none", "none/none");
            this.amulet = new Amulet("none", "none/none");
            this.ring = new Ring("none", "none/none");
            this.blessing = new Blessing("none", "none/none");
            this.potions = InventoryHandler.PotionList();
        }

        

        public void AddPotion(string potionName){
            for(int i = 0; i < 5; i++){
                if(potionName == potions[i].name){
                    potions[i].potionNumber++;
                }
            }
        }

        public int CalcCoins(int lower, int upper){
            int coinsGained = Functions.GetRandomNum(lower, upper);
            return coinsGained;
        }

        public void AddCoins(int coinsGained){
            System.Console.WriteLine($"You have gained {coinsGained} coins!");
            coins += coinsGained;
        }
    }
}