namespace cgiComp
{
    public class Elite
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
        
        public string elementalDamage { get; set; }

        public Elite(string Name, int MaxHealth, int Damage, string Behavior, int speed, int defense, string elementalDamage){
            this.Name = Name;
            this.MaxHealth = MaxHealth;
            this.Health = MaxHealth;  
            this.Damage = Damage;
            this.Behavior = Behavior;
            this.speed = speed;
            this.defense = defense;
            this.isCharged = false;
            this.isDead = false;
            this.elementalDamage = elementalDamage;
        }

        public void DealDamage(Player player, int resistance){
            int monsterRoll = Functions.Roll20();
            int damageMultiplier;

            System.Console.WriteLine($"{Name} rolled a {monsterRoll}");

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


            if(player.health <= 0){
                player.isDead = true;
                Functions.DisplayMessage("Lose");
            }
        }

        public void DealElementalDamage(Player player){
            string line = elementalDamage;
            string[] array = line.Split('/');
            string type = array[0];
            int damage = int.Parse(array[1]);

            if(type != player.resistance){
                System.Console.WriteLine($"The {Name} dealt {damage} {type} damage");
                player.health -= damage;
            } else {
                System.Console.WriteLine($"You resisted the {type} damage!");
            }

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