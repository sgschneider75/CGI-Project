namespace cgiComp
{
    public class Menu
    {
        public static int SelectFightOption(string[] menuOptions, Player player, Monster monster){
            int selected = 1;
            bool answerSelected = false;
            
            while(answerSelected == false){
                System.Console.WriteLine("player's health:" + player.health);
                System.Console.WriteLine("monster's health:" + monster.Health);

                for(int i = 0; i < menuOptions.Length; i++){
                    if(i+1 == selected){
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                    }
                    System.Console.WriteLine(menuOptions[i]);
                    Console.ResetColor();
                }
                var key = Console.ReadKey(true).Key;
                if(key == ConsoleKey.DownArrow){
                    selected = selected + 1;
                } else if (key == ConsoleKey.UpArrow){
                    selected = selected - 1;
                } else if (key == ConsoleKey.Enter){
                    answerSelected = true;
                }

                if(selected > menuOptions.Length){
                    selected = 1;
                } else if(selected == 0){
                    selected = menuOptions.Length;
                }

            Console.Clear();
            }
            
            return selected;
        }
    }
}