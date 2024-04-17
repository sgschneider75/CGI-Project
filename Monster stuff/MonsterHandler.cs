namespace cgiComp
{
    public class MonsterHandler
    {
        private Monster monster;

        public MonsterHandler(Monster monster){
            this.monster = monster;
        }

        public static int GetAction(Monster monster){
            string line = monster.Behavior;
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
                if(monster.isCharged == true){
                    monsterMove = 1;
                }
            }

            return monsterMove;
        }
    }
}