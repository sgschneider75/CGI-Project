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

        public void AddItemBonus(string itemBonus){
            string[] bonusInfo = itemBonus.Split('/');
            int x = 0;
            int y = 1;
            int i = 0;
            while(i < bonusInfo.Length && bonusInfo[x] != "r"){
                if(bonusInfo[x] == "p"){
                    player.power += int.Parse(bonusInfo[y]);
                } else if (bonusInfo[x] == "s"){
                    player.speed += int.Parse(bonusInfo[y]);
                } else if (bonusInfo[x] == "d"){
                    player.defense += int.Parse(bonusInfo[y]);
                } else if (bonusInfo[x] == "a"){
                    player.power += int.Parse(bonusInfo[y])*5;
                    player.speed += int.Parse(bonusInfo[y]);
                    player.defense += int.Parse(bonusInfo[y]);
                    player.maxHealth += int.Parse(bonusInfo[y])*5;
                    player.health += int.Parse(bonusInfo[y])*5;
                } else if (bonusInfo[x] == "mh"){
                    player.health += int.Parse(bonusInfo[y]);
                    player.maxHealth += int.Parse(bonusInfo[y]);
                }
            }

            if(bonusInfo[0] == "r"){
                if(bonusInfo[1] == "c"){
                    player.resistance = "cold";
                } else if (bonusInfo[1] == "f"){
                    player.resistance = "fire";
                } else if (bonusInfo[1] == "e"){
                    player.resistance = "earth";
                } else if(bonusInfo[1] == "w"){
                    player.resistance = "wind";
                } else {
                    player.resistance = "dark";
                }
            }
        }

        public void RemoveItemBonus(string itemBonus){
            string[] bonusInfo = itemBonus.Split('/');
            int x = 0;
            int y = 1;
            int i = 0;
            while(i < bonusInfo.Length && bonusInfo[x] != "r"){
                if(bonusInfo[x] == "p"){
                    player.power -= int.Parse(bonusInfo[y]);
                } else if (bonusInfo[x] == "s"){
                    player.speed -= int.Parse(bonusInfo[y]);
                } else if (bonusInfo[x] == "d"){
                    player.defense -= int.Parse(bonusInfo[y]);
                } else if (bonusInfo[x] == "a"){
                    player.power -= int.Parse(bonusInfo[y]);
                    player.speed -= int.Parse(bonusInfo[y]);
                    player.defense -= int.Parse(bonusInfo[y]);
                } else if (bonusInfo[x] == "mh"){
                    player.maxHealth -= int.Parse(bonusInfo[y]);
                }
            }

            if(bonusInfo[0] == "r"){
                player.resistance = "none";
            }
        }
    }
}