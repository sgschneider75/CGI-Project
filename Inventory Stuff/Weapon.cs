namespace cgiComp
{
    public class Weapon
    {
        private PlayerHandler playerHandler;
        public string name { get; set; }

        public int damage { get; set; }

        public string[] bonuses { get; set; }

        public Weapon(PlayerHandler playerHandler, string name, int damage, string bonuses){
            this.playerHandler = playerHandler;
            this.name = name;
            this.damage = damage;
            this.bonuses = GetWeaponBonus();
        }

        public void ApplyWeaponBonus(Player player){
            player.damage = player.damage + damage;
            int i = 0;
            while(bonuses[i] != null){
                playerHandler.GetItemBonus(bonuses[i]);
                i++;
            }
            
        }

        public void RemoveWeaponBonus(Player player){
            player.damage = player.damage - damage;
            int i = 0;
            while(bonuses[i] != null){
                playerHandler.RemoveItemBonus(bonuses[i]);
                i++;
            }
        }
    }
}