using System.Runtime.InteropServices;
using cgiComp;
using cgiComp.Battle_Stuff;
using cgiComp.Monster_stuff;

PlayerHandler playerHandler = new PlayerHandler();

Monster[] emptyMonArray = new Monster[24];

Elite[] emptyEliteArray = new Elite[9];

Boss[] emptyBossArray = new Boss[1];

MonsterFileHandler monsterFileHandler= new MonsterFileHandler(emptyMonArray);

EliteFileHandler eliteFileHandler = new EliteFileHandler (emptyEliteArray);

BossFileHandler bossFileHandler = new BossFileHandler(emptyBossArray);

Worlds worlds = new Worlds(monsterFileHandler.monsterList, eliteFileHandler.eliteList, bossFileHandler.bossList, playerHandler);

worlds.TravelWorld1();


// StreamReader sr = new StreamReader("Goblin");

// string line = sr.ReadLine();

// while (line != null){
//     System.Console.WriteLine(line);
//     line = sr.ReadLine();
// }
