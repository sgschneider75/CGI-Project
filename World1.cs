using cgiComp.Battle_Stuff;

namespace cgiComp
{
    public class World1
    {
        private Monster[] monsterList;

        private Player player;

        private BattleHandler battleHandler;
        
        public World1(Monster[] monsterList, Player player){
            this.monsterList = monsterList;
            this.player = player;
            battleHandler = new BattleHandler();
        }

        public void EnterRoom(int roomNumber){
            int roomChoice = Functions.GetRandomNum(1, 4);

            if(roomChoice == 4){
                MysteryRoom();
            } else {
                BattleRandomMonster(roomNumber);
            }
                
            
        }

        public void EnterEliteSplitRoom(int enemyNumber, int eliteNumber){
            int randomNum = Functions.GetRandomNum(1, 4);

            if(randomNum == 4){
                BattleElite(eliteNumber);
            } else {
                BattleMonster(enemyNumber);
            }
        }

        public void EnterEliteRoom(int eliteNumber){
            BattleElite(eliteNumber);
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
            while(player.isDead == false && monster.isDead == false){
                battleHandler.BattleRound(player, monster);
            }
        }

        public void BattleMonster(int enemyNumber){
            Monster monster = monsterList[enemyNumber - 1];
            while(player.isDead == false && monster.isDead == false){
                battleHandler.BattleRound(player, monster);
            }
        }

        public void BattleElite(int eliteNumber){

        }

        public void BattleBoss(int bossNumber){
            
        }
    }
}