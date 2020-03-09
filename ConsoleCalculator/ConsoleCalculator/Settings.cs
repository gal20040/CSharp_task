namespace ConsoleCalculator
{
    public static class Settings
    {
        public static char fractionSeparator = ',';
        public static string dotSeparator = ".";

        internal static bool Debug = false;

        internal static string UnknownValueTemplate = "Неизвестное значение %0: %1";
        internal static string NoItemsTemplate = "%0 не имеет элементов";
    }
}