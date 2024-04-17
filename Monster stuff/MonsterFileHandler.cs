namespace cgiComp
{
    public class MonsterFileHandler
    {
        private Monster[] monsterList;

        public void GetAllMonsters(){
            StreamReader inFile = new StreamReader("Monsters");

            string line = inFile.ReadLine();
            int i = 0;

            while(line != null){
                string[] monsterInfo = line.Split('#');

                monsterList[i] = new Monster(monsterInfo[0], int.Parse(monsterInfo[1]), int.Parse(monsterInfo[2]), monsterInfo[3], int.Parse(monsterInfo[4]), int.Parse(monsterInfo[5]));
                i++;
            }

            inFile.Close();
        }

        public Monster GetMonster(int id){
            return monsterList[id - 1];
        }
    }
}