using System.Runtime.InteropServices;
using cgiComp;
using cgiComp.Battle_Stuff;
using cgiComp.Monster_stuff;

Monster[] emptyMonArray = new Monster[24];

Elite[] emptyEliteArray = new Elite[9];

Boss[] emptyBossArray = new Boss[4];

MonsterFileHandler monsterFileHandler= new MonsterFileHandler(emptyMonArray);

EliteFileHandler eliteFileHandler = new EliteFileHandler (emptyEliteArray);

BossFileHandler bossFileHandler = new BossFileHandler(emptyBossArray);

Console.Clear();

Functions.DisplayMessage("Welcome");


System.Console.WriteLine("What difficulty level would you like? (1/2/3)");
System.Console.WriteLine("(1 is a tutorial)");

string userInput = Console.ReadLine();
string difficulty = "BaseStats1";
switch (userInput){
    case "1":
        System.Console.WriteLine("Difficulty set to 1");
        break;
    case "2":
        System.Console.WriteLine("Difficulty set to 2");
        difficulty = "BaseStats2";
        break;
    case "3":
        System.Console.WriteLine("Difficulty set to 3");
        difficulty = "BaseStats3";
        break;
    default:
        System.Console.WriteLine("Error, setting difficulty to 1");
        break;
}

PlayerHandler playerHandler = new PlayerHandler(difficulty);

Worlds worlds = new Worlds(monsterFileHandler.monsterList, eliteFileHandler.eliteList, bossFileHandler.bossList, playerHandler);

worlds.TravelWorld1();

if(playerHandler.player.isDead != true){
    worlds.TravelWorld2();
}

if(playerHandler.player.isDead != true){
    worlds.TravelWorld3();
}

if(playerHandler.player.isDead != true){
    System.Console.WriteLine("You have defeated the Dark Lord and cleansed his presense");
    System.Console.WriteLine("Victory is yours!!");
    System.Console.WriteLine("You retire a hero, with your best friend the shopkeeper");
    Functions.DisplayMessage("Win");
}


