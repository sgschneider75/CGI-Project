namespace cgiComp
{
    public class Player
    {
        public string username {get; set;}

        public int health {get; set;}

        public int maxHealth {get; set;}

        public int damage {get; set;}

        public int power {get; set;}

        public int speed {get; set;}

        public int defense {get; set;}

        public bool isDead {get; set;}

        public bool isCharged {get; set;}

        public string resistance {get; set;}

        // Charge Status, increases damage, but dissapears with an attack

        public Player (string username, int maxHealth, int damage){
            this.username = username;
            this.maxHealth = maxHealth;
            this.health = maxHealth;
            this.damage = damage;
            this.power = 0;
            this.speed = 0;
            this.defense = 0;
            this.isDead = false;
            this.isCharged = false;
            this.resistance = "none";
        }
    }
}