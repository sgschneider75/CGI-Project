namespace cgiComp
{
    public class Monster
    {
        public string Name{ get; set; }

        public int Health { get; set; }

        public int MaxHealth { get; set; }

        public int Damage { get; set; }

        public string Behavior { get; set; }

        public int speed;

        public int defense;

        public bool isCharged {get; set;}

        public bool isDead {get; set;}

        public Monster(string Name, int MaxHealth, int Damage, string Behavior, int speed, int defense){
            this.Name = Name;
            this.MaxHealth = MaxHealth;
            this.Health = MaxHealth;  
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


            if(monsterRoll <= 2){
                damageMultiplier = 0;
            } else if (monsterRoll <= 18){
                damageMultiplier = 1;
            } else {
                damageMultiplier = 2;
            }

            int totalDamage = Damage*damageMultiplier;

            if(isCharged == true){
                totalDamage = totalDamage*2;
                isCharged = false;
            }

            player.health -= (totalDamage / resistance);

            System.Console.WriteLine($"The monster lashed out and dealt {totalDamage / resistance} damage");

            if(player.health <= 0){
                player.isDead = true;
                Functions.DisplayMessage("Lose");
            }
        }

        public void ChargeUp(){
            isCharged = true;
            System.Console.WriteLine($"the {Name} is charged up");
        }
    }
}