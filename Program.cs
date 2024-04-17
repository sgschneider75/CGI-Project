using System.Runtime.InteropServices;
using cgiComp;
using cgiComp.Battle_Stuff;


Player player = PlayerCreator.CreatePlayer();

Monster monster = new Monster("goblin", 50, 10, "6/3/1");

BattleHandler battleHandler= new BattleHandler();

while(player.isDead == false && monster.isDead == false){
    battleHandler.BattleRound(player, monster);
}


System.Console.WriteLine(player.health);


// StreamReader sr = new StreamReader("Goblin");

// string line = sr.ReadLine();

// while (line != null){
//     System.Console.WriteLine(line);
//     line = sr.ReadLine();
// }
