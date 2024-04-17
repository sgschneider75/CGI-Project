namespace cgiComp
{
    public class Player
    {
        public string username {get; set;}

        public int health {get; set;}

        public int damage {get; set;}

        public int power {get; set;}

        public int speed {get; set;}

        public int defense {get; set;}

        public bool isDead {get; set;}

        public Inventory inventory {get; set;}

        public bool isCharged {get; set;}

        // Charge Status, increases damage, but dissapears with an attack

        public Player (string username, int health, int damage){
            this.username = username;
            this.health = health;
            this.damage = damage;
            this.power = 0;
            this.speed = 0;
            this.defense = 0;
            this.isDead = false;
            this.inventory = new Inventory();
            this.isCharged = false;
        }

        public void DealDamage(Monster monster, int resistance){
            double damageMultiplier;

            int playerRoll = Functions.Roll20();

            if(playerRoll == 1){
                damageMultiplier = 0;
            } else if (playerRoll <= 6){
                damageMultiplier = 0.5;
            } else if (playerRoll <= 14){
                damageMultiplier = 1;
            } else if (playerRoll <= 19){
                damageMultiplier = 1.5;
            } else {
                damageMultiplier = 2;
            }

            double damageCalc = damage*damageMultiplier;
            int damageInt = Convert.ToInt32(damageCalc);
            int totalDamage = damageInt + power;

            if(isCharged == true){
                totalDamage = totalDamage*2;
                isCharged = false;
            }

            if(playerRoll == 0){
                totalDamage = 0;
            }
           
            monster.Health = monster.Health - (totalDamage / resistance);

            System.Console.WriteLine($"You struck and dealt {totalDamage / resistance} damage");

            if(monster.Health <= 0){
                monster.isDead = true;
                System.Console.WriteLine("You killed the monster");
            }
        }

        public void ChargeUp(){
            isCharged = true;
        }


    }
}