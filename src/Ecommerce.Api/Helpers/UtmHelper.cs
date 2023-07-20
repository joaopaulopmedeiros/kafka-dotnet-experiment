namespace Ecommerce.Api.Helpers;

public class UtmHelper
{
    public static Utm Mount(string input)
    {
        return new Utm
        {
            Source = GetString(input, "source"),
            Medium = GetString(input, "medium"),
            Campaign = GetString(input, "campaign"),
        };
    }

    public static string GetString(string input, string pattern)
    {
        TimeSpan timeout = TimeSpan.FromMilliseconds(100);

        RegexOptions options = RegexOptions.None;

        string searchFor = @"utm_" + pattern + @"=([A-Za-z0-9_\-]+)";

        input ??= string.Empty;

        Match match = Regex.Match(input, searchFor, options, timeout);

        return match.Success ? match.Groups[1].Value : null;
    }
}
