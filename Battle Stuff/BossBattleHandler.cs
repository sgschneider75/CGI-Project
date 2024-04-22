using cgiComp.Monster_stuff;

namespace cgiComp
{
    public class BossBattleHandler
    {
        public void BattleRound(PlayerHandler playerHandler, Boss monster){
            Functions.ClearScreen();
            string[] menuOptions = new string[3];
            MenuOptions.FightOptions(menuOptions);

            int playerAction = Menu.SelectBossFightOption(menuOptions, playerHandler.player, monster);

            int monsterAction = BossHandler.GetAction(monster);

            if(playerAction == 1){
                System.Console.WriteLine("You chose to attack");
            } else if (playerAction == 2){
                System.Console.WriteLine("You chose to defend");
            } else {
                System.Console.WriteLine("You chose to charge up");
            }

            if(monsterAction == 1){
                System.Console.WriteLine("the monster chose to attack");
            } else if (monsterAction == 2){
                System.Console.WriteLine("the monster chose to defend");
            } else {
                System.Console.WriteLine("the monster chose to charge up");
            }
            
            
            switch(playerAction){
                case 1:
                    if(monsterAction == 1){
                        AttackAttack(playerHandler, monster);
                    } else if (monsterAction == 2){
                        AttackDefend(playerHandler, monster);
                    } else {
                        AttackCharge(playerHandler, monster);
                    }
                    break;
                case 2:
                    if(monsterAction == 1){
                        DefendAttack(playerHandler.player, monster);
                    } else if (monsterAction == 2){
                        DefendDefend(playerHandler.player, monster);
                    } else {
                        DefendCharge(playerHandler.player, monster);
                    }
                    break;
                case 3:
                    if(monsterAction == 1){
                        ChargeAttack(playerHandler.player, monster);
                    } else if (monsterAction == 2){
                        ChargeDefend(playerHandler);
                    } else {
                        ChargeCharge(playerHandler, monster);
                    }
                    break;
                
            }
        }

        public void AttackAttack(PlayerHandler playerHandler, Boss monster){
            int playerRoll = Functions.Roll20() + (playerHandler.player.speed);
            int monsterRoll = Functions.Roll20() + (monster.speed);

            System.Console.WriteLine($"You rolled a {playerRoll}");
            System.Console.WriteLine($"{monster.Name} rolled a {monsterRoll}");

            if(playerRoll > monsterRoll){
                System.Console.WriteLine("You successfully attacked first");
                playerHandler.DealDamage(monster, 1);
            } else if (playerRoll == monsterRoll){
                System.Console.WriteLine("You both struck each other");
                playerHandler.DealDamage(monster, 1);
                monster.DealDamage(playerHandler.player, 1);
            } else {
                System.Console.WriteLine($"The {monster.Name} struck first");
                monster.DealDamage(playerHandler.player, 1);
            }

        }

        public void AttackDefend(PlayerHandler playerHandler, Boss monster){
            int playerRoll = Functions.Roll20() + (playerHandler.player.speed);
            int monsterRoll = Functions.Roll20() + 5 + monster.defense;

            System.Console.WriteLine($"You rolled a {playerRoll}");
            System.Console.WriteLine($"{monster.Name} rolled a {monsterRoll}");

            if(playerRoll > monsterRoll){
                System.Console.WriteLine($"You broke through the {monster.Name}'s defense");
                playerHandler.DealDamage(monster, 2);
            } else {
                System.Console.WriteLine($"The {monster.Name}'s defense stood");
                playerHandler.player.isCharged = false;
            }
        }

        public void AttackCharge(PlayerHandler playerHandler, Boss monster){
            playerHandler.DealDamage(monster, 1);
        }

        public void DefendAttack(Player player, Boss monster){
            int playerRoll = Functions.Roll20() + 10 + (player.defense);
            int monsterRoll = Functions.Roll20() + (monster.speed);

            System.Console.WriteLine($"You rolled a {playerRoll}");
            System.Console.WriteLine($"{monster.Name} rolled a {monsterRoll}");

            if(playerRoll < monsterRoll){
                System.Console.WriteLine(monster.Name + "broke through your defense"); 
                monster.DealDamage(player, 2);
            } else {
                monster.isCharged = false; 
            }
        }

        public void DefendDefend(Player player, Boss monster){
            
        }

        public void DefendCharge(Player player, Boss monster){
            monster.ChargeUp();
        }

        public void ChargeAttack(Player player, Boss monster){
            monster.DealDamage(player, 1);
        }

        public void ChargeDefend(PlayerHandler playerHandler){
            playerHandler.ChargeUp();
        }

        public void ChargeCharge(PlayerHandler playerHandler, Boss monster){
            playerHandler.ChargeUp();
            monster.ChargeUp();
        }
    }
}