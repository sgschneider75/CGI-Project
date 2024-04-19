using cgiComp.Battle_Stuff;

namespace cgiComp
{
    public class Worlds
    {
        private Monster[] monsterList;

        private Elite[] eliteList;

        private PlayerHandler playerHandler;

        private BattleHandler battleHandler;

        private EliteBattleHandler eliteBattleHandler;
        
        public Worlds(Monster[] monsterList, Elite[] eliteList, PlayerHandler playerHandler){
            this.monsterList = monsterList;
            this.eliteList = eliteList;
            this.playerHandler = playerHandler;
            battleHandler = new BattleHandler();
            eliteBattleHandler = new EliteBattleHandler();
        }

        public void TravelWorld1(){
            int userChoice;
            // Flavor Text
            // Monster Flavor Text
            BattleRandomMonster(1);
            if(playerHandler.player.isDead == false){
                //Flavor text cave or forest
                userChoice = Menu.SelectOption(MenuOptions.CaveForest());

                if(userChoice == 1){
                    //Monster Cave Flavor Text
                    BattleRandomMonster(2);
                } else {
                    // Forest Monster Flavor Text
                    BattleRandomMonster(3);
                }

                if(playerHandler.player.isDead == false){
                    if(userChoice == 1){
                        // Tunnel Gnome text
                        BattleElite(1);
                    } else {
                        //Bridge Troll Text
                        BattleElite(2);
                    }
                }

            }

            // Shop

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

                    // Boss Room Text

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


        public void EnterBossRoom(int bossNumber){
            BattleBoss(bossNumber);
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
            
        }
    }
}