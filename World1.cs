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
                BattleEnemy(roomNumber);
            }
                
            
        }




        public Monster GetEnemy(int x, int y){
            int enemyNum = Functions.GetRandomNum(x, y);

            return monsterList[enemyNum - 1];
        }


        public void MysteryRoom(){

        }

        public void BattleEnemy(int roomNumber){
            roomNumber = roomNumber - 1;
            int x = 1 + (3*roomNumber);
            int y = 3 + (3*roomNumber);
            Monster monster = GetEnemy(x, y);
            while(player.isDead == false && monster.isDead == false){
                battleHandler.BattleRound(player, monster);
            }
        }
    }
}