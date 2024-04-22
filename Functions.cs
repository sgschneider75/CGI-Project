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
            StreamReader inFile = new StreamReader(message);

            string line = inFile.ReadLine();

            while (line != null){
                System.Console.WriteLine(line);
                line = inFile.ReadLine();
            }

            inFile.Close();
        }
    }
}