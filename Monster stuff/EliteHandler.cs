namespace cgiComp
{
    public class EliteHandler
    {
        private Elite elite;

        public EliteHandler(Elite elite){
            this.elite = elite;
        }

        public static int GetAction(Elite elite){
            string line = elite.Behavior;
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
                if(elite.isCharged == true){
                    monsterMove = 1;
                }
            }

            return monsterMove;
        }
    }
}