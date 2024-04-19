using System.Runtime.InteropServices;
using cgiComp;
using cgiComp.Battle_Stuff;


Player player = PlayerCreator.CreatePlayer();

Monster[] emptyArray = new Monster[24];

MonsterFileHandler fileHandler= new MonsterFileHandler(emptyArray);

World1 world1 = new World1(fileHandler.monsterList, player);

world1.TravelWorld1();



System.Console.WriteLine(player.health);


// StreamReader sr = new StreamReader("Goblin");

// string line = sr.ReadLine();

// while (line != null){
//     System.Console.WriteLine(line);
//     line = sr.ReadLine();
// }
