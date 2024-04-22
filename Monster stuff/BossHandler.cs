namespace cgiComp.Monster_stuff
{
    public class BossHandler
    {
        private Boss boss;

        public BossHandler(Boss boss){
            this.boss = boss;
        }

        public static int GetAction(Boss boss){
            string line = boss.Behavior;
            string[] behavior = line.Split('/');
            int attackChance = int.Parse(behavior[0]);
            int defendChance = int.Parse(behavior[1]);
            int chargeChance = int.Parse(behavior[2]);


            int monsterMove;
            int randomNum = Functions.GetRandomNum(1, 10);

            if(randomNum <= attackChance){
                monsterMove = 1;
            } else if (randomNum <= attackChance + defendChance){
                monsterMove = 2;
            } else {
                monsterMove = 3;
            }

            if(monsterMove == 3){
                if(boss.isCharged == true){
                    monsterMove = 1;
                }
            }

            return monsterMove;
        }
    }
}