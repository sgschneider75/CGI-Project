using System.Runtime.InteropServices;
using cgiComp;
using cgiComp.Battle_Stuff;

PlayerHandler playerHandler = new PlayerHandler();

Monster[] emptyMonArray = new Monster[24];

Elite[] emptyEliteArray = new Elite[9];

MonsterFileHandler monsterFileHandler= new MonsterFileHandler(emptyMonArray);

EliteFileHandler eliteFileHandler = new EliteFileHandler (emptyEliteArray);

Worlds worlds = new Worlds(monsterFileHandler.monsterList, eliteFileHandler.eliteList, playerHandler);

worlds.TravelWorld1();


// StreamReader sr = new StreamReader("Goblin");

// string line = sr.ReadLine();

// while (line != null){
//     System.Console.WriteLine(line);
//     line = sr.ReadLine();
// }
