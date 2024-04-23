using cgiComp.Monster_stuff;

namespace cgiComp
{
    public class PlayerHandler
    {
        public Player player { get; set; }

        public Inventory inventory{ get; set; }
        public PlayerHandler(string level){
            this.player = PlayerCreator.CreatePlayer(level);
            this.inventory = new Inventory();
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

            double damageCalc = player.damage*damageMultiplier;
            int damageInt = Convert.ToInt32(damageCalc);
            int totalDamage = damageInt + player.power;

            if(player.isCharged == true){
                totalDamage = totalDamage*2;
                player.isCharged = false;
            }

            if(playerRoll == 0){
                totalDamage = 0;
            }
           
            monster.Health -= (totalDamage / resistance);

            System.Console.WriteLine($"You struck and dealt {totalDamage / resistance} damage");

            if(monster.Health <= 0){
                monster.isDead = true;
                System.Console.WriteLine("You killed the monster");
            }
        }

        public void DealDamage(Elite monster, int resistance){
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

            double damageCalc = player.damage*damageMultiplier;
            int damageInt = Convert.ToInt32(damageCalc);
            int totalDamage = damageInt + player.power;

            if(player.isCharged == true){
                totalDamage = totalDamage*2;
                player.isCharged = false;
            }

            if(playerRoll == 0){
                totalDamage = 0;
            }
           
            monster.Health -= (totalDamage / resistance);

            System.Console.WriteLine($"You struck and dealt {totalDamage / resistance} damage");

            if(monster.Health <= 0){
                monster.isDead = true;
                System.Console.WriteLine("You killed the monster");
            }
        }

        public void DealDamage(Boss monster, int resistance){
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

            double damageCalc = player.damage*damageMultiplier;
            int damageInt = Convert.ToInt32(damageCalc);
            int totalDamage = damageInt + player.power;

            if(player.isCharged == true){
                totalDamage = totalDamage*2;
                player.isCharged = false;
            }

            if(playerRoll == 0){
                totalDamage = 0;
            }
           
            monster.Health -= (totalDamage / resistance);

            System.Console.WriteLine($"You struck and dealt {totalDamage / resistance} damage");

            if(monster.Health <= 0){
                monster.isDead = true;
                System.Console.WriteLine("You killed the monster");
            }
        }

        public void ChargeUp(){
            player.isCharged = true;
            System.Console.WriteLine("You are charged up!");
        }


        public void ApplyItemBonus(string itemBonus){
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
                i += 2;
                x += 2;
                y += 2;
            }

            if(bonusInfo[0] == "r"){
                if(bonusInfo[1] == "c"){
                    player.resistance = "water";
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
                i += 2;
            }

            if(bonusInfo[0] == "r"){
                player.resistance = "none";
            }
        }

        public void ApplyWeaponBonus(Weapon weapon){
            player.damage = player.damage + weapon.damage;
            ApplyItemBonus(weapon.bonus);
            
        }

        public void RemoveWeaponBonus(Weapon weapon){
            player.damage = player.damage - weapon.damage;
            RemoveItemBonus(weapon.bonus);
        }

        public void ChangeWeapon(Weapon weapon){
            RemoveWeaponBonus(inventory.weapon);
            inventory.weapon = weapon;
            ApplyWeaponBonus(inventory.weapon);
        }

        public void ChangeRing(Ring ring){
            RemoveItemBonus(inventory.ring.bonus);
            inventory.ring = ring;
            ApplyItemBonus(inventory.ring.bonus);
        }

        public void ChangeTrinket(Trinket trinket){
            RemoveItemBonus(inventory.trinket.bonus);
            inventory.trinket = trinket;
            ApplyItemBonus(inventory.trinket.bonus);
        }

        public void ChangeAmulet(Amulet amulet){
            RemoveItemBonus(inventory.amulet.bonus);
            inventory.amulet = amulet;
            ApplyItemBonus(inventory.amulet.bonus);
        }

        public void ChangeBlessing(Blessing blessing){
            RemoveItemBonus(inventory.blessing.bonus);
            inventory.blessing = blessing;
            ApplyItemBonus(inventory.blessing.bonus);
        }
    }
}