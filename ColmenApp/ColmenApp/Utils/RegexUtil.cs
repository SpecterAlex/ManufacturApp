using System.Text.RegularExpressions;

namespace ColmenApp.Utils
{
    public static class RegexUtil
    {
        public static Regex ValidEmailAdress()
        {
            return new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        public static Regex MinLength(int length)
        {
            return new Regex(@"^(\s*(\S)\s*){" + length + @",}");
        }

        public static Regex ValidZipCode()
        {
            return new Regex(@"^\d{5}?$");
        }
    }
}
