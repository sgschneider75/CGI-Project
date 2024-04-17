namespace cgiComp
{
    public class PlayerHandler
    {
        Player player;
        public PlayerHandler(Player player){
            this.player = player;
        }

        public void takeDamage (int damage){
            player.health = player.health - damage;
            if(player.health < 0){
                System.Console.WriteLine($"You have taken {damage} damage and died. Game Over!");
                player.isDead = true;
            } else {
                System.Console.WriteLine($"You have taken {damage} damage");
            }
        }

        public void GetItemBonus(string itemBonus){
            string[] bonusInfo = itemBonus.Split('/');

            if(bonusInfo[0] == "p"){
                player.power += int.Parse(bonusInfo[1]);
            } else if (bonusInfo[0] == "s"){
                player.speed += int.Parse(bonusInfo[1]);
            } else if (bonusInfo[0] == "d"){
                player.defense += int.Parse(bonusInfo[1]);
            } else if (bonusInfo[0] == "a"){
                player.power += int.Parse(bonusInfo[1]);
                player.speed += int.Parse(bonusInfo[1]);
                player.defense += int.Parse(bonusInfo[1]);
            }
        }

        public void RemoveItemBonus(string itemBonus){
            string[] bonusInfo = itemBonus.Split('/');

            if(bonusInfo[0] == "p"){
                player.power -= int.Parse(bonusInfo[1]);
            } else if (bonusInfo[0] == "s"){
                player.speed -= int.Parse(bonusInfo[1]);
            } else if (bonusInfo[0] == "d"){
                player.defense -= int.Parse(bonusInfo[1]);
            } else if (bonusInfo[0] == "a"){
                player.power -= int.Parse(bonusInfo[1]);
                player.speed -= int.Parse(bonusInfo[1]);
                player.defense -= int.Parse(bonusInfo[1]);
            }
        }
    }
}