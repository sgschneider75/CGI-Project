namespace cgiComp
{
    public class MenuOptions
    {
        public static string[] FightOptions(string[] menuOptions){
            menuOptions[0] = "1. Attack";
            menuOptions[1] = "2. Defend";
            menuOptions[2] = "3. Charge Up";

            return menuOptions;
        }

        public static string[] CaveForest(){
            string[] options = new string[2];

            options[0] = "Climb into the cave";
            options[1] = "Venture into the forest";

            return options;
        }

        public static string[] WallSewer(){
            string[] options = new string[2];

            options[0] = "Scale the wall";
            options[1] = "Sneak in through the sewer";

            return options;
        }
    }
}