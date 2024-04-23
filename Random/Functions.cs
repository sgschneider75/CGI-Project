namespace cgiComp
{
    public class Functions
    {
        public static int GetRandomNum(int lower, int upper){
            Random rnd = new Random();
            return rnd.Next(lower, upper + 1);
        }

        public static int Roll20 (){
            return GetRandomNum(1, 20);
        }

        public static void ClearScreen(){
            System.Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        public static void DisplayMessage(string message){
            StreamReader inFile = new StreamReader("C:\\Users\\Sgsch\\documents\\coding\\cgicomp\\ASCIIART\\" + message);

            string line = inFile.ReadLine();

            while (line != null){
                System.Console.WriteLine(line);
                line = inFile.ReadLine();
            }

            inFile.Close();
        }

        public static void DisplayHealth(int health, int maxHealth, string name){
            
            double num = health;
            double num1 = maxHealth;
            double perNum = 100*(num/num1);


            System.Console.WriteLine(name + $": {health}/{maxHealth}");
            Console.BackgroundColor = ConsoleColor.Green;
            
            for(int i = 0; i < perNum; i++){
                Console.Write(" ");
            }

            
            Console.BackgroundColor= ConsoleColor.Red;
            for(double i = 0; i < 100 - perNum; i++){
                
                Console.Write(" ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            System.Console.WriteLine("");
        }
    }
}