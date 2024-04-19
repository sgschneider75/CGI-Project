namespace cgiComp
{
    public class InventoryHandler
    {

        private static Weapon[] weaponList = GetWeaponList();

        private static Blessing[] blessingList = GetBlessingList();
        private static Amulet[] amuletList = GetAmuletList();

        private static Ring[] ringList = GetRingList();

        private static Trinket[] trinketList = GetTrinketList();

        
        public static Weapon[] GetWeaponList(){
            Weapon[] weaponList = new Weapon[5];

            weaponList[0] = new Weapon("Dagger", 10, "s/2/p/-5");
            weaponList[1] = new Weapon("Hammer", 20, "s/-2/p/15");
            weaponList[2] = new Weapon("Sword", 15, "s/1/p/5/d/1");
            weaponList[3] = new Weapon("Spear", 15, "s/1/p/10");
            weaponList[4] = new Weapon("Shield", 5, "s/-1/d/4");

            return weaponList;
        }

        public static Blessing[] GetBlessingList(){
            Blessing[] blessingList = new Blessing[4];

            blessingList[0] = new Blessing("Wind", "s/3");
            blessingList[0] = new Blessing("Fire", "p/15");
            blessingList[0] = new Blessing("Earth", "d/3");
            blessingList[0] = new Blessing("Water", "mh/20");


            return blessingList;
        }

        public static Amulet[] GetAmuletList(){
            Amulet[] amuletList = new Amulet[5];

            amuletList[0] = new Amulet("Fire Spark", "r/f");
            amuletList[1] = new Amulet("Water Drop", "r/w");
            amuletList[2] = new Amulet("Earth Stone", "r/e");
            amuletList[3] = new Amulet("Wind Current", "r/w");
            amuletList[4] = new Amulet("Dark Shadow", "r/d");

            return amuletList;
        }

        public static Ring[] GetRingList(){
            Ring[] ringList = new Ring[5];

            ringList[0] = new Ring("Speed Ring", "s/2");
            ringList[1] = new Ring("Defense Ring", "d/2");
            ringList[2] = new Ring("Power Ring", "p/10");
            ringList[3] = new Ring("Health Ring", "mh/15");

            return ringList;
        }

        public static Trinket[] GetTrinketList(){
            Trinket[] trinketList = new Trinket[5];

            trinketList[0] = new Trinket("Turtle's Shell", "d/2/mh/15");
            trinketList[0] = new Trinket("Tiger's Claw", "p/10/mh/10");
            trinketList[0] = new Trinket("Eagle Feather", "s/3/p/5");
            trinketList[0] = new Trinket("Dragon's Fang", "a/2");


            return trinketList;
        }

        public static Potion[] PotionList(){
            Potion[] potionList = new Potion[5];

            potionList[0] = new Potion("Health", "h/25");
            potionList[1] = new Potion("Speed Up", "s/5");
            potionList[2] = new Potion("Defense Up", "d/7");
            potionList[3] = new Potion("Power Up", "p/15");
            potionList[4] = new Potion("Charge Up", "c/1");

            return potionList;
        }
    }
}