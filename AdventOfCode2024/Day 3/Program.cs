using System;
using System.Text.RegularExpressions;

string[] seperators = { "do()", "don't()" };
string text = File.ReadAllText("..\\..\\..\\Data.txt");
string[] segments = Regex.Split(text, @"(do\(\)|don't\(\))");
string pattern = @"mul\(\d+,\d+\)";
MatchCollection matches = Regex.Matches(text, pattern);
int result = 0;


/*
// Part 1
foreach (Match match in matches)
{
    string element = match.Value;
    int val1 = int.Parse(element.Substring(4, element.IndexOf(",") - 4));
    int val2 = int.Parse(element.Substring(element.IndexOf(",") + 1, element.IndexOf(")") - 1 - element.IndexOf(",")));
    result += val1 * val2;
}
*/

// Part 2
for (int i = 0; i < segments.Length; i++)
{
    if (i == 0 || segments[i - 1].Equals("do()"))
    {
        MatchCollection _matches = Regex.Matches(segments[i], pattern);

        foreach (Match match in _matches)
        {
            string element = match.Value;
            int val1 = int.Parse(element.Substring(4, element.IndexOf(",") - 4));
            int val2 = int.Parse(element.Substring(element.IndexOf(",") + 1, element.IndexOf(")") - 1 - element.IndexOf(",")));
            result += val1 * val2;
        }
    }
}

Console.WriteLine(result);