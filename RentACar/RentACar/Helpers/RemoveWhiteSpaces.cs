using System.Text.RegularExpressions;

namespace RentACar.Helpers
{
    public class RemoveWhiteSpaces
    {
        private static readonly Regex sWhitespace = new Regex(@"\s+");
        public static string ReplaceWhitespace(string input, string replacement)
        {
            return sWhitespace.Replace(input, replacement);
        }
    }
}

//thanks to https://stackoverflow.com/questions/6219454/efficient-way-to-remove-all-whitespace-from-string