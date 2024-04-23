namespace cgiComp.Monster_stuff
{
    public class BossFileHandler
    {
        public Boss[] bossList;

        public BossFileHandler(Boss[] bossList){
            this.bossList = GetAllBosses(bossList);
        }

        public Boss[] GetAllBosses(Boss[] bossList){
            StreamReader inFile = new StreamReader("C:\\Users\\Sgsch\\documents\\coding\\cgicomp\\Monster Stuff\\Bosses");

            string line = inFile.ReadLine();
            int i = 0;

            while(line != null){
                string[] monsterInfo = line.Split('#');

                bossList[i] = new Boss(monsterInfo[0], int.Parse(monsterInfo[1]), int.Parse(monsterInfo[2]), monsterInfo[3], int.Parse(monsterInfo[4]), int.Parse(monsterInfo[5]), monsterInfo[6], int.Parse(monsterInfo[7]));
                line = inFile.ReadLine();
                i++;
            }

            inFile.Close();

            return bossList;
        }

        public Boss GetBoss(int id){
            return bossList[id - 1];
        }
    }
}