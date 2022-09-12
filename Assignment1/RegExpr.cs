namespace Assignment1;
using System.Text.RegularExpressions;

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines) 
    {
        foreach (var line in lines) 
        {
            foreach (Match match in Regex.Matches(line, @"(\w+)"))
            {
                yield return match.Value;
            }  
        }
    }

    public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> resolutions) 
    {
         foreach (var res in resolutions) 
        {
            foreach (Match match in Regex.Matches(res, @"(?<width>\d+)x(?<height>\d+)"))
            {
                yield return (int.Parse(match.Groups["width"].Value), int.Parse(match.Groups["height"].Value));
            }  
        }
    }

    public static IEnumerable<string> InnerText(string html, string tag) => throw new NotImplementedException();

    public static IEnumerable<(Uri url, string title)> Urls(string html) => throw new NotImplementedException();
}
