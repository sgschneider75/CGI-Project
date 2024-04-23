namespace cgiComp
{
    public class ASCII
    {

        public static string GetArt(string name){
            string total = "";
            int i = 0;

            StreamReader inFile = new StreamReader("C:\\Users\\Sgsch\\documents\\coding\\cgicomp\\ASCIIART\\" + name);
            string line = inFile.ReadLine();
            while(line != null){
            total += "\n";
            total += line;
            line = inFile.ReadLine();
            }

            inFile.Close();
            return total;
        }
    }
}