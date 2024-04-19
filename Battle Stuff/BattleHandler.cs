namespace cgiComp.Battle_Stuff
{
    public class BattleHandler
    {


        public void BattleRound(Player player, Monster monster){
            Functions.ClearScreen();
            string[] menuOptions = new string[3];
            MenuOptions.FightOptions(menuOptions);

            int playerAction = Menu.SelectFightOption(menuOptions, player, monster);

            int monsterAction = MonsterHandler.GetAction(monster);

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
                        AttackAttack(player, monster);
                    } else if (monsterAction == 2){
                        AttackDefend(player, monster);
                    } else {
                        AttackCharge(player, monster);
                    }
                    break;
                case 2:
                    if(monsterAction == 1){
                        DefendAttack(player, monster);
                    } else if (monsterAction == 2){
                        DefendDefend(player, monster);
                    } else {
                        DefendCharge(player, monster);
                    }
                    break;
                case 3:
                    if(monsterAction == 1){
                        ChargeAttack(player, monster);
                    } else if (monsterAction == 2){
                        ChargeDefend(player, monster);
                    } else {
                        ChargeCharge(player, monster);
                    }
                    break;
                
            }
        }

        public void AttackAttack(Player player, Monster monster){
            int playerRoll = Functions.Roll20() + (player.speed / 2);
            int monsterRoll = Functions.Roll20() + (monster.speed/2);

            System.Console.WriteLine($"You rolled a {playerRoll}");
            System.Console.WriteLine($"{monster.Name} rolled a {monsterRoll}");

            if(playerRoll > monsterRoll){
                System.Console.WriteLine("You successfully attacked first");
                player.DealDamage(monster, 1);
            } else if (playerRoll == monsterRoll){
                System.Console.WriteLine("You both struck each other");
                player.DealDamage(monster, 1);
                monster.DealDamage(player, 1);
            } else {
                System.Console.WriteLine($"The {monster.Name} struck first");
                monster.DealDamage(player, 1);
            }

        }

        public void AttackDefend(Player player, Monster monster){
            int playerRoll = Functions.Roll20() + (player.speed / 2);
            int monsterRoll = Functions.Roll20() + 10 + monster.defense;

            System.Console.WriteLine($"You rolled a {playerRoll}");
            System.Console.WriteLine($"{monster.Name} rolled a {monsterRoll}");

            if(playerRoll > monsterRoll){
                System.Console.WriteLine($"You broke through the {monster.Name}'s defense");
                player.DealDamage(monster, 2);
            } else {
                System.Console.WriteLine($"The {monster.Name}'s defense stood");
                player.isCharged = false;
            }
        }

        public void AttackCharge(Player player, Monster monster){
            player.DealDamage(monster, 1);
        }

        public void DefendAttack(Player player, Monster monster){
            int playerRoll = Functions.Roll20() + 10 + (player.defense / 2);
            int monsterRoll = Functions.Roll20() + (monster.speed/2);

            System.Console.WriteLine($"You rolled a {playerRoll}");
            System.Console.WriteLine($"{monster.Name} rolled a {monsterRoll}");

            if(playerRoll < monsterRoll){
                System.Console.WriteLine(monster.Name + "broke through your defense"); 
                monster.DealDamage(player, 2);
            } else {
                monster.isCharged = false; 
            }
        }

        public void DefendDefend(Player player, Monster monster){
            
        }

        public void DefendCharge(Player player, Monster monster){
            monster.ChargeUp();
        }

        public void ChargeAttack(Player player, Monster monster){
            monster.DealDamage(player, 1);
        }

        public void ChargeDefend(Player player, Monster monster){
            player.ChargeUp();
        }

        public void ChargeCharge(Player player, Monster monster){
            player.ChargeUp();
            monster.ChargeUp();
        }
    }
}