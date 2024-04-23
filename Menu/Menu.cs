using cgiComp.Monster_stuff;

namespace cgiComp
{
    public class Menu
    {
        public static int SelectFightOption(string[] menuOptions, Player player, Monster monster, string line){
            int selected = 1;
            bool answerSelected = false;
            
            while(answerSelected == false){
                System.Console.WriteLine(line);
                Functions.DisplayHealth(monster.Health, monster.MaxHealth, monster.Name);
                Functions.DisplayHealth(player.health, player.maxHealth, player.username);

                for(int i = 0; i < menuOptions.Length; i++){
                    if(i+1 == selected){
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                    }
                    System.Console.WriteLine(menuOptions[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
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

        public static int SelectEliteFightOption(string[] menuOptions, Player player, Elite elite, string line){
            int selected = 1;
            bool answerSelected = false;
            
            while(answerSelected == false){
                System.Console.WriteLine(line);
                Functions.DisplayHealth(elite.Health, elite.MaxHealth, elite.Name);
                Functions.DisplayHealth(player.health, player.maxHealth, player.username);

                for(int i = 0; i < menuOptions.Length; i++){
                    if(i+1 == selected){
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                    }
                    System.Console.WriteLine(menuOptions[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
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

        public static int SelectBossFightOption(string[] menuOptions, Player player, Boss elite, string line){
            int selected = 1;
            bool answerSelected = false;
            
            while(answerSelected == false){
                System.Console.WriteLine(line);
                Functions.DisplayHealth(elite.Health, elite.MaxHealth, elite.Name);
                Functions.DisplayHealth(player.health, player.maxHealth, player.username);

                for(int i = 0; i < menuOptions.Length; i++){
                    if(i+1 == selected){
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                    }
                    System.Console.WriteLine(menuOptions[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
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

        public static int SelectOption(string[] menuOptions){
            int selected = 1;
            bool answerSelected = false;
            
            while(answerSelected == false){
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