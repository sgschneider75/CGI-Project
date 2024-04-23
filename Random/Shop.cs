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
            System.Console.WriteLine("Welcome to the Shop! Here you can purchase items to boost your abilities with coins");
            System.Console.WriteLine("Please note that the purchase of an item will automatically replace any equipped items of that type");
            
            string userInput = "";

            int weaponNum = Functions.GetRandomNum(1,5);
            int amuletNum = Functions.GetRandomNum(1,5);
            int trinketNum = Functions.GetRandomNum(1,4);
            int ringNum = Functions.GetRandomNum(1,4);


            while(userInput != "5"){
                System.Console.WriteLine("1. Weapon\n2. Amulet\n3. Trinket\n4. Ring\n5. Exit");
                userInput = Console.ReadLine();

                switch(userInput){
                    case "1":
                        WeaponStore(weaponNum);
                        System.Console.WriteLine("got here");
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

            System.Console.WriteLine($"Coins: {inventory.coins}");

            weapon.WriteStats();

            System.Console.WriteLine($"Would you like to purchase this weapon for {weaponCost} coins?\n1. Buy Weapon\n2. Cancel");

            string uInput = Console.ReadLine();

            switch(uInput){
                case "1":
                    if(inventory.coins >= weaponCost){
                        System.Console.WriteLine($"You have successfully purchased the {weapon.name}");
                        inventory.coins -= weaponCost;
                        playerHandler.ChangeWeapon(weapon);
                        System.Console.WriteLine("got here");
                    } else {
                        System.Console.WriteLine("you cannot afford this weapon");
                    }
                    break;
                case "2":
                    System.Console.WriteLine("Canceling");
                    break;
                default:
                    System.Console.WriteLine("Please enter a valid choice, 1 or 2. Canceling");
                    break;
            }
        }

        private void AmuletStore(int amuletNum){
            Amulet amulet = InventoryHandler.amuletList[amuletNum -1];

            System.Console.WriteLine($"Coins: {inventory.coins}");

            amulet.WriteStats();

            System.Console.WriteLine($"Would you like to purchase this amulet for {amuletCost} coins?\n1. Buy Amulet\n2. Cancel");

            string uInput = Console.ReadLine();

            switch(uInput){
                case "1":
                    if(inventory.coins >= amuletCost){
                        System.Console.WriteLine($"You have successfully purchased the {amulet.name}");
                        inventory.coins -= amuletCost;
                        playerHandler.ChangeAmulet(amulet);
                    } else {
                        System.Console.WriteLine("you cannot afford this amulet");
                    }
                    break;
                case "2":
                    System.Console.WriteLine("Canceling");
                    break;
                default:
                    System.Console.WriteLine("Please enter a valid choice, 1 or 2. Canceling");
                    break;
            }
        }

        private void TrinketStore(int trinketNum){
            Trinket trinket = InventoryHandler.trinketList[trinketNum -1];

            System.Console.WriteLine($"Coins: {inventory.coins}");

            trinket.WriteStats();

            System.Console.WriteLine($"Would you like to purchase this trinket for {trinketCost} coins?\n1. Buy trinket\n2. Cancel");

            string uInput = Console.ReadLine();

            switch(uInput){
                case "1":
                    if(inventory.coins >= trinketCost){
                        System.Console.WriteLine($"You have successfully purchased the {trinket.name}");
                        inventory.coins -= trinketCost;
                        playerHandler.ChangeTrinket(trinket);
                    } else {
                        System.Console.WriteLine("you cannot afford this trinket");
                    }
                    break;
                case "2":
                    System.Console.WriteLine("Canceling");
                    break;
                default:
                    System.Console.WriteLine("Please enter a valid choice, 1 or 2. Canceling");
                    break;
            }
        }

        private void RingStore(int ringNum){
            Ring ring = InventoryHandler.ringList[ringNum -1];

            System.Console.WriteLine($"Coins: {inventory.coins}");

            ring.WriteStats();

            System.Console.WriteLine($"Would you like to purchase this ring for {ringCost} coins?\n1. Buy ring\n2. Cancel");

            string uInput = Console.ReadLine();

            switch(uInput){
                case "1":
                    if(inventory.coins >= ringCost){
                        System.Console.WriteLine($"You have successfully purchased the {ring.name}");
                        inventory.coins -= ringCost;
                        playerHandler.ChangeRing(ring);
                    } else {
                        System.Console.WriteLine("you cannot afford this ring");
                    }
                    break;
                case "2":
                    System.Console.WriteLine("Canceling");
                    break;
                default:
                    System.Console.WriteLine("Please enter a valid choice, 1 or 2. Canceling");
                    break;
            }
        }


    }
}