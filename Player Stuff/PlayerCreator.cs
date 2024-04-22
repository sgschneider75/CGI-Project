namespace cgiComp
{
    public class PlayerCreator
    {
        public static Player CreatePlayer(string level){
            System.Console.WriteLine("What would you like to name your player?");

            string username = Console.ReadLine();
            
            StreamReader inFile = new StreamReader(@"\Users\Sgsch\documents\coding\cgiComp\Player Stuff\" + level);

            string line = inFile.ReadLine();
            string[] stats = line.Split('#');


            
            Player player = new Player(username, int.Parse(stats[0]), int.Parse(stats[1]));

            inFile.Close();

            return player;
        }
    }
}