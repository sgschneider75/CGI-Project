namespace cgiComp
{
    public class Shop
    {
        private Inventory inventory { get; set; }
        
        private PlayerHandler playerHandler { get; set; }

        private static int weaponCost = 100;

        private static int amuletCost = 20;

        private static int trinketCost = 50;

        private static int ringCost = 20;


        public Shop(PlayerHandler playerHandler, Inventory inventory){
            this.playerHandler = playerHandler;
            this.inventory = inventory;
        }



        public void ShopMenu(){
            //Shop Flavor Text
            
            string userInput = "";

            int weaponNum = Functions.GetRandomNum(1,5);
            int amuletNum = Functions.GetRandomNum(1,5);
            int trinketNum = Functions.GetRandomNum(1,5);
            int ringNum = Functions.GetRandomNum(1,5);


            while(userInput != "5"){
                System.Console.WriteLine("1. Weapon\n2. Amulet\n3. Trinket\n4. Ring\n5. Exit");
                userInput = Console.ReadLine();

                switch(userInput){
                    case "1":
                        WeaponStore(weaponNum);
                        break;
                    case "2":
                        AmuletStore(amuletNum);
                        break;
                    case "3":
                        TrinketStore(trinketNum);
                        break;
                    case "4":
                        RingStore(ringNum);
                        break;
                    case "5":
                        System.Console.WriteLine("Exiting store");
                        break;
                    default:
                        System.Console.WriteLine("Error, please enter a valid option");
                        break;
                }
            }
        }

        private void WeaponStore(int weaponNum){
            Weapon weapon = InventoryHandler.weaponList[weaponNum -1];
        }

        private void AmuletStore(int amuletNum){
            Amulet amulet = InventoryHandler.amuletList[amuletNum -1];

        }

        private void TrinketStore(int trinketNum){
            Trinket trinket = InventoryHandler.trinketList[trinketNum -1];

        }

        private void RingStore(int ringNum){
            Ring ring = InventoryHandler.ringList[ringNum -1];

        }


    }
}