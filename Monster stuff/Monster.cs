namespace cgiComp
{
    public class Monster
    {
        public string Name{ get; set; }

        public int Health { get; set; }

        public int Damage { get; set; }

        public string Behavior { get; set; }

        public int speed;

        public int defense;

        public bool isCharged {get; set;}

        public bool isDead {get; set;}

        public Monster(string Name, int Health, int Damage, string Behavior, int speed, int defense){
            this.Name = Name;
            this.Health = Health;  
            this.Damage = Damage;
            this.Behavior = Behavior;
            this.speed = speed;
            this.defense = defense;
            this.isCharged = false;
            this.isDead = false;
        }

        public void DealDamage(Player player, int resistance){
            int monsterRoll = Functions.Roll20();
            int damageMultiplier;

            if(monsterRoll <= 4){
                damageMultiplier = 0;
            } else if (monsterRoll <= 17){
                damageMultiplier = 1;
            } else {
                damageMultiplier = 2;
            }

            int totalDamage = Damage*damageMultiplier;

            if(isCharged == true){
                totalDamage = totalDamage*2;
                isCharged = false;
            }

            player.health = player.health - (totalDamage / resistance);

            System.Console.WriteLine($"The monster lashed out and dealt {totalDamage / resistance} damage");

            if(player.health <= 0){
                player.isDead = true;
                System.Console.WriteLine("You died");
            }
        }

        public void ChargeUp(){
            isCharged = true;
        }
    }
}