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
    }
}