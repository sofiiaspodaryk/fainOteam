using System.Text;

namespace Polotno.API.Functions;

public class UkToEnTransliterator
{
    private static readonly Dictionary<string, string> TransliterationMap = new Dictionary<string, string>
    {
        {"а", "a"}, {"б", "b"}, {"в", "v"}, {"г", "h"}, {"ґ", "g"}, {"д", "d"}, {"е", "e"}, {"є", "ye"},
        {"ж", "zh"}, {"з", "z"}, {"и", "y"}, {"і", "i"}, {"ї", "yi"}, {"й", "y"}, {"к", "k"},
        {"л", "l"}, {"м", "m"}, {"н", "n"}, {"о", "o"}, {"п", "p"}, {"р", "r"}, {"с", "s"},
        {"т", "t"}, {"у", "u"}, {"ф", "f"}, {"х", "kh"}, {"ц", "ts"}, {"ч", "ch"}, {"ш", "sh"},
        {"щ", "shch"}, {"ь", ""}, {"ю", "yu"}, {"я", "ya"}, {" ", "_"}
    };

    public static string ToTranslit(string input)
    {
        input = input.ToLower();
        var result = new StringBuilder();

        foreach (var ch in input)
        {
            var charStr = ch.ToString();
            if (TransliterationMap.ContainsKey(charStr))
            {
                result.Append(TransliterationMap[charStr]);
            }
            else
            {
                result.Append(charStr);
            }
        }
        return result.ToString();
    }
}
