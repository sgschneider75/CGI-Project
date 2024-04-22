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
            // Flavor Text
            // Monster Flavor Text
            BattleRandomMonster(1);
            playerHandler.inventory.AddCoins(playerHandler.inventory.CalcCoins(1, 10));
            if(playerHandler.player.isDead == false){
                //Flavor text cave or forest
                userChoice = Menu.SelectOption(MenuOptions.CaveForest());

                if(userChoice == 1){
                    //Monster Cave Flavor Text
                    BattleRandomMonster(2);
                    playerHandler.inventory.AddCoins(playerHandler.inventory.CalcCoins(5, 15));
                } else {
                    // Forest Monster Flavor Text
                    BattleRandomMonster(3);
                    playerHandler.inventory.AddCoins(playerHandler.inventory.CalcCoins(5, 15));
                }

                if(playerHandler.player.isDead == false){
                    if(userChoice == 1){
                        // Tunnel Gnome text
                        BattleElite(1);
                        playerHandler.inventory.AddCoins(playerHandler.inventory.CalcCoins(10, 20));
                    } else {
                        //Bridge Troll Text
                        BattleElite(2);
                        playerHandler.inventory.AddCoins(playerHandler.inventory.CalcCoins(5, 20));
                    }
                }

            }

            shop.ShopMenu();

            if(playerHandler.player.isDead == false){
                // Split flavor text
                userChoice = Menu.SelectOption(MenuOptions.WallSewer());
                
                if(userChoice == 1){
                    EnterEliteSplitRoom(19, 3);
                } else {
                    EnterEliteSplitRoom(20, 4);
                }

                if(playerHandler.player.isDead == false){
                    // Heal Room Flavor Text
                    playerHandler.player.health += 30;
                    if(playerHandler.player.health > playerHandler.player.maxHealth){
                        playerHandler.player.health = playerHandler.player.maxHealth;
                    }

                    BattleBoss(1);

                }

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
            while(playerHandler.player.isDead == false && monster.isDead == false){
                battleHandler.BattleRound(playerHandler, monster);
            }
        }

        public void BattleMonster(int enemyNumber){
            Monster monster = monsterList[enemyNumber - 1];
            while(playerHandler.player.isDead == false && monster.isDead == false){
                battleHandler.BattleRound(playerHandler, monster);
            }
        }

        public void BattleElite(int eliteNumber){
            Elite elite = eliteList[eliteNumber - 1];
            int i = 1;

            while(playerHandler.player.isDead == false && elite.isDead == false){
                eliteBattleHandler.BattleRound(playerHandler, elite);
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
                
                bossBattleHandler.BattleRound(playerHandler, boss);
                if(i % 5 == 0){
                    System.Console.WriteLine($"{boss.Name} lashes out with a elemental attack");
                    boss.DealElementalDamage(playerHandler.player);
                }

                i++;
            }
        }
    }
}