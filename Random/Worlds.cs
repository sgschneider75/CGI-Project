using cgiComp.Battle_Stuff;
using cgiComp.Monster_stuff;

namespace cgiComp
{
    public class Worlds
    {
        private Monster[] monsterList;

        private Elite[] eliteList;

        private Boss[] bossList;

        private PlayerHandler playerHandler;

        private BattleHandler battleHandler;

        private EliteBattleHandler eliteBattleHandler;

        private BossBattleHandler bossBattleHandler;

        private Shop shop;
        
        public Worlds(Monster[] monsterList, Elite[] eliteList, Boss[] bossList, PlayerHandler playerHandler){
            this.monsterList = monsterList;
            this.eliteList = eliteList;
            this.bossList = bossList;
            this.playerHandler = playerHandler;
            battleHandler = new BattleHandler();
            eliteBattleHandler = new EliteBattleHandler();
            bossBattleHandler = new BossBattleHandler();
            shop = new Shop(playerHandler, playerHandler.inventory);
        }

        public void TravelWorld1(){
            int userChoice;
            Functions.ClearScreen();
            Functions.DisplayMessage("Clouds");
            System.Console.WriteLine("As you begin your adventure across the world, you stumble upon a kingdom in ruins");
            System.Console.WriteLine("Intruiged, you venture towards the capital");
            System.Console.WriteLine("You enter the plains, but hear a rustling behind you");
            BattleRandomMonster(1);
            playerHandler.inventory.AddCoins(playerHandler.inventory.CalcCoins(1, 10));
            if(playerHandler.player.isDead == false){
                System.Console.WriteLine("As you continue on your journey, you come across a forest between you and the capital");
                System.Console.WriteLine("You could enter the forest, or take a shortcut through a cave");
                userChoice = Menu.SelectOption(MenuOptions.CaveForest());

                if(userChoice == 1){
                    System.Console.WriteLine("As you enter the darkness, a figure appears before you");
                    Functions.ClearScreen();
                    BattleRandomMonster(2);
                    playerHandler.inventory.AddCoins(playerHandler.inventory.CalcCoins(5, 15));
                    Functions.ClearScreen();
                } else {
                    Functions.DisplayMessage("Forest");
                    System.Console.WriteLine("As you walk through the dark woods, you hear a rustling in the bushes");
                    Functions.ClearScreen();
                    BattleRandomMonster(3);
                    playerHandler.inventory.AddCoins(playerHandler.inventory.CalcCoins(5, 15));
                    Functions.ClearScreen();
                }

                if(playerHandler.player.isDead == false){
                    if(userChoice == 1){
                        Functions.DisplayMessage("Torch");
                        System.Console.WriteLine("As you near the exit to the cave, you hear the omninous rumbling of treads");
                        Functions.ClearScreen();
                        BattleElite(1);
                        playerHandler.inventory.AddCoins(playerHandler.inventory.CalcCoins(10, 20));
                        Functions.ClearScreen();
                    } else {
                        Functions.DisplayMessage("Bridge");
                        System.Console.WriteLine("You exit the woods to a great bridge and begin to cross, but a large figure shambling in front of you");
                        Functions.ClearScreen();
                        BattleElite(2);
                        playerHandler.inventory.AddCoins(playerHandler.inventory.CalcCoins(10, 20));
                        Functions.ClearScreen();
                    }
                }

            }

            if(playerHandler.player.isDead == false){
                System.Console.WriteLine("As you approach the large capital, you find the people gone and the place abandoned, except for a small shop");
                System.Console.WriteLine("As you enter the shop, a kind voice welcomes you");
                Functions.ClearScreen();
                shop.ShopMenu();
            }

            

            if(playerHandler.player.isDead == false){
                Functions.DisplayMessage("Castle");
                System.Console.WriteLine("Finally, you approach the castle, but you need to find a way in");
                userChoice = Menu.SelectOption(MenuOptions.WallSewer());
                
                if(userChoice == 1){
                    Functions.DisplayMessage("Wall");
                    System.Console.WriteLine("As you climb over the top of the wall, you hear a firm voice commanding you to halt");
                    Functions.ClearScreen();
                    EnterEliteSplitRoom(19, 3);
                    playerHandler.inventory.AddCoins(playerHandler.inventory.CalcCoins(10, 25));
                    Functions.ClearScreen();
                } else {
                    System.Console.WriteLine("As you sludge through the disgust, you hear chittering around you");
                    EnterEliteSplitRoom(20, 4);
                    playerHandler.inventory.AddCoins(playerHandler.inventory.CalcCoins(10, 25));
                    Functions.ClearScreen();
                }

                if(playerHandler.player.isDead == false){
                    System.Console.WriteLine("You approach the throne room, stopping to take a sip of a nearby foutain, healing some health");
                    playerHandler.player.health += 30;
                    if(playerHandler.player.health > playerHandler.player.maxHealth){
                        playerHandler.player.health = playerHandler.player.maxHealth;
                    }
                    System.Console.WriteLine("You push through the doors, to find a crazed figure on the throne");
                    System.Console.WriteLine("He rushes you as your prepare for battle");
                    Functions.ClearScreen();
                    BattleBoss(1);
                    playerHandler.inventory.AddCoins(playerHandler.inventory.CalcCoins(20, 25));
                    Functions.ClearScreen();

                    if(playerHandler.player.isDead != true){
                        System.Console.WriteLine("You defeated the crazed king, restoring order to the kingdom. But it leaves you wondering...");
                        System.Console.WriteLine("Who corrupted the king? and what will they do next");
                        Functions.ClearScreen();
                    }
                }

            }

        }


        public void TravelWorld2(){
            int userChoice;
            Functions.DisplayMessage("Sun");
            System.Console.WriteLine("As you exit the plains kingdom, honored as a hero, you enter a nearby desert");
            System.Console.WriteLine("Unfortunately, deserts are not known for their safety...");
            Functions.ClearScreen();
            BattleRandomMonster(4);
            playerHandler.inventory.AddCoins(playerHandler.inventory.CalcCoins(10, 20));
            Functions.ClearScreen();
            if(playerHandler.player.isDead == false){
                System.Console.WriteLine("As you defeat your enemy, you must decide where to go next");
                userChoice = Menu.SelectOption(MenuOptions.Canyons());

                if(userChoice == 1){
                    System.Console.WriteLine("You climb down a ladder into the canyon, when you are struck from behind");
                    Functions.ClearScreen();
                    BattleRandomMonster(5);
                    playerHandler.inventory.AddCoins(playerHandler.inventory.CalcCoins(15, 20));
                    Functions.ClearScreen();
                } else {
                    System.Console.WriteLine("You venture across the plains, when you are rushed by a dark figure");
                    Functions.ClearScreen();
                    BattleRandomMonster(6);
                    playerHandler.inventory.AddCoins(playerHandler.inventory.CalcCoins(15, 20));
                    Functions.ClearScreen();
                }

                if(playerHandler.player.isDead == false){
                    if(userChoice == 1){
                        System.Console.WriteLine("You defeat your adversary, but you slip and tumble into a dark hole");
                        System.Console.WriteLine("You wake in an area, facing an enraged foe between you and the exit");
                        Functions.ClearScreen();
                        BattleElite(5);
                        playerHandler.inventory.AddCoins(playerHandler.inventory.CalcCoins(20, 25));
                        Functions.ClearScreen();
                    } else {
                        System.Console.WriteLine("After your battle, you seek shelter in an abandoned shack");
                        System.Console.WriteLine("As you push through the door, you hear a screaming sound approaching");
                        Functions.ClearScreen();
                        BattleElite(6);
                        playerHandler.inventory.AddCoins(playerHandler.inventory.CalcCoins(20, 25));
                        Functions.ClearScreen();
                    }
                }

            }

            if(playerHandler.player.isDead == false){
                Functions.DisplayMessage("Pyramid");
                System.Console.WriteLine("You discover a large pyramid, and decide to head to it, but not before visiting the desert trader");
                System.Console.WriteLine("As you approach, you realize the trader is somehow the same old man as before");
                System.Console.WriteLine("'Welcome Back'");
                Functions.ClearScreen();
                shop.ShopMenu();
            }


            

            if(playerHandler.player.isDead == false){
                System.Console.WriteLine("As you approach the temple, a dark cloud appears and you hear distant chanting");
                userChoice = Menu.SelectOption(MenuOptions.Stairs());
                
                if(userChoice == 1){
                    System.Console.WriteLine("You rush into the front door, hoping you have time to stop whatever is happening at the top");
                    System.Console.WriteLine("As you run through the halls, you are beset by a hooded figure");
                    Functions.ClearScreen();
                    EnterEliteSplitRoom(21, 7);
                    playerHandler.inventory.AddCoins(playerHandler.inventory.CalcCoins(15, 25));
                    Functions.ClearScreen();
                } else {
                    System.Console.WriteLine("No time for the entrance, you sprint up the outside steps");
                    System.Console.WriteLine("'You will go no futhur' a booming voice resounds");
                    Functions.ClearScreen();
                    EnterEliteSplitRoom(22, 8);
                    playerHandler.inventory.AddCoins(playerHandler.inventory.CalcCoins(15, 25));
                    Functions.ClearScreen();
                }

                if(playerHandler.player.isDead == false){
                    System.Console.WriteLine("As you near the top of the temple, you quickly drink your emergency potion");
                    playerHandler.player.health += 30;
                    if(playerHandler.player.health > playerHandler.player.maxHealth){
                        playerHandler.player.health = playerHandler.player.maxHealth;
                    }

                    if(userChoice == 1){
                        System.Console.WriteLine("As you exit the final door, you are met by a horrifying sight");
                        System.Console.WriteLine("A large dragon is chewing on a robed corpse, you prepare for battle");
                        Functions.ClearScreen();
                        BattleBoss(2);
                        playerHandler.inventory.AddCoins(playerHandler.inventory.CalcCoins(25, 30));
                        Functions.ClearScreen();
                    } else {
                        System.Console.WriteLine("As you reach the top of the stairs, you hear");
                        System.Console.WriteLine("'you will pay dearly for distrubing my plan'");
                        Functions.ClearScreen();
                        BattleBoss(3);
                        playerHandler.inventory.AddCoins(playerHandler.inventory.CalcCoins(25, 30));
                        Functions.ClearScreen();
                    }

                    
                    if(playerHandler.player.isDead == false){
                        System.Console.WriteLine("As you put a stop to the chaos at the top of the tower, you once again wonder the origin");
                        System.Console.WriteLine("Suddenly, a pitch black hoke appears below you and you fall in");
                    }
                }

            }

        }

        public void TravelWorld3(){
            System.Console.WriteLine("You land roughly, standing on a glossy black surface, spreading as far as the eye can see");

            int num = Functions.GetRandomNum(1,2);

            if(num == 1){
                System.Console.WriteLine("You hear a shuffling sound behind you");
                Functions.ClearScreen();
                BattleMonster(23);
            } else {
                System.Console.WriteLine("A chill goes down your spine");
                BattleMonster(24);
                Functions.ClearScreen();
            }

            if(playerHandler.player.isDead == false){
                System.Console.WriteLine("'You may have defeated my minion, but can you defeat my right hand'");
                System.Console.WriteLine("A figure in black armor appears");
                Functions.ClearScreen();
                BattleElite(9);
                Functions.ClearScreen();
            }

            if(playerHandler.player.isDead == false){
                System.Console.WriteLine("As you prepare to face the mastermind, a portal opens next to you, showing a friendly face");
                Functions.ClearScreen();

                shop.ShopMenu();

                System.Console.WriteLine("'One last blessing, for the enemy you face'");
                System.Console.WriteLine("He waves his hand and you feel refreshed");

                playerHandler.player.health = playerHandler.player.maxHealth;

                BattleBoss(4);
                Functions.ClearScreen();
            }
        }

        public void EnterRoom(int roomNumber){
            int roomChoice = Functions.GetRandomNum(1, 4);

            roomChoice = 2;
            
            if(roomChoice == 4){
                MysteryRoom();
            } else {
                BattleRandomMonster(roomNumber);
            }
                
            
        }

        public void EnterEliteSplitRoom(int enemyNumber, int eliteNumber){
            int randomNum = Functions.GetRandomNum(1, 4);

            if(randomNum >= 3){
                BattleElite(eliteNumber);
            } else {
                BattleMonster(enemyNumber);
            }
        }




        public Monster GetEnemy(int x, int y){
            int enemyNum = Functions.GetRandomNum(x, y);

            return monsterList[enemyNum - 1];
        }


        public void MysteryRoom(){

        }

        public void BattleRandomMonster(int roomNumber){
            roomNumber = roomNumber - 1;
            int x = 1 + (3*roomNumber);
            int y = 3 + (3*roomNumber);
            Monster monster = GetEnemy(x, y);
            string line = ASCII.GetArt(monster.Name);
            while(playerHandler.player.isDead == false && monster.isDead == false){
                battleHandler.BattleRound(playerHandler, monster, line);
            }
        }

        public void BattleMonster(int enemyNumber){
            Monster monster = monsterList[enemyNumber - 1];
            string line = ASCII.GetArt(monster.Name);
            while(playerHandler.player.isDead == false && monster.isDead == false){
                battleHandler.BattleRound(playerHandler, monster, line);
            }
        }

        public void BattleElite(int eliteNumber){
            Elite elite = eliteList[eliteNumber - 1];
            int i = 1;
            string line = ASCII.GetArt(elite.Name);
            while(playerHandler.player.isDead == false && elite.isDead == false){
                eliteBattleHandler.BattleRound(playerHandler, elite, line);
                if(i % 5 == 0){
                    System.Console.WriteLine($"{elite.Name} lashes out with a elemental attack");
                    elite.DealElementalDamage(playerHandler.player);
                }

                i++;
            }

        }

        public void BattleBoss(int bossNumber){
            Boss boss = bossList[bossNumber - 1];
            int i = 1;
            string line = ASCII.GetArt(boss.Name);
            while(playerHandler.player.isDead == false && boss.isDead == false){
                if(boss.Health < boss.MaxHealth/2){
                    if(boss.isEnraged == false){
                        boss.isEnraged = true;
                        System.Console.WriteLine($"{boss.Name} explodes with red light as he becomes enraged");
                    }
                    
                }

                if(boss.isEnraged == true){
                    if(i % 3 == 0){
                        System.Console.WriteLine($"{boss.Name} flickers with red light as his rage festers");
                    boss.Health += boss.healAmount;
                    boss.isCharged = true;
                    if(boss.Health > boss.MaxHealth){
                        boss.Health = boss.MaxHealth;
                    }
                    }
                }
                
                bossBattleHandler.BattleRound(playerHandler, boss, line);
                if(i % 5 == 0){
                    System.Console.WriteLine($"{boss.Name} lashes out with a elemental attack");
                    boss.DealElementalDamage(playerHandler.player);
                }

                i++;
            }
        }
    }
}