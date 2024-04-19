namespace cgiComp
{
    public class EliteFileHandler
    {
        public Elite[] eliteList;

        public EliteFileHandler(Elite[] eliteList){
            this.eliteList = GetAllElites(eliteList);
        }

        public Elite[] GetAllElites(Elite[] eliteList){
            StreamReader inFile = new StreamReader("Elites");

            string line = inFile.ReadLine();
            int i = 0;

            while(line != null){
                string[] monsterInfo = line.Split('#');

                eliteList[i] = new Elite(monsterInfo[0], int.Parse(monsterInfo[1]), int.Parse(monsterInfo[2]), monsterInfo[3], int.Parse(monsterInfo[4]), int.Parse(monsterInfo[5]), monsterInfo[6]);
                line = inFile.ReadLine();
                i++;
            }

            inFile.Close();

            return eliteList;
        }

        public Elite GetElite(int id){
            return eliteList[id - 1];
        }
    }
}