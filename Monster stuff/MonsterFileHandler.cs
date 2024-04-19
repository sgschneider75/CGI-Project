namespace cgiComp
{
    public class MonsterFileHandler
    {
        public Monster[] monsterList;

        public MonsterFileHandler(Monster[] monsterList){
            this.monsterList = GetAllMonsters(monsterList);
        }

        public Monster[] GetAllMonsters(Monster[] monsterList){
            StreamReader inFile = new StreamReader("Monsters");

            string line = inFile.ReadLine();
            int i = 0;

            while(line != null){
                string[] monsterInfo = line.Split('#');

                monsterList[i] = new Monster(monsterInfo[0], int.Parse(monsterInfo[1]), int.Parse(monsterInfo[2]), monsterInfo[3], int.Parse(monsterInfo[4]), int.Parse(monsterInfo[5]));
                line = inFile.ReadLine();
                i++;
            }

            inFile.Close();

            return monsterList;
        }

        public Monster GetMonster(int id){
            return monsterList[id - 1];
        }
    }
}