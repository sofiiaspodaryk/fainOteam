using System.Text;

namespace Polotno.API.Functions;

class UrlByNameGenerator
{
    private const String BASE_URL = "https://storage.googleapis.com/polotno-bucket-1/";
    public static string GenerateUrlByName(string name, string? storing_directory=null)
    {
        var result = new StringBuilder();

        if (!string.IsNullOrEmpty(storing_directory))
        {
            result.Append(storing_directory + "/");
        }

        var transliteratedName = UkToEnTransliterator.ToTranslit(name);
        result.Append(transliteratedName + ".jpeg");
        
        return result.ToString();
    }
}
