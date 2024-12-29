using System;
using System.Text.RegularExpressions;

string[] lines = File.ReadAllLines("..\\..\\..\\Data.txt");
int count = 0;

/* Part 1
// Horizontal
foreach (string line in lines)
{
    count += Regex.Matches(line, "XMAS").Count() + Regex.Matches(line, "SAMX").Count();
}

// Vertical
for (int i = 0; i < lines[0].Length; i++)
{
    string vertical = "";
    foreach (string line in lines)
    {
        vertical += line.Substring(i, 1);
    }

    count += Regex.Matches(vertical, "XMAS").Count() + Regex.Matches(vertical, "SAMX").Count();
}

// Right Diagonal
for (int i = 0; i < lines[0].Length; i++)
{
    string diagonal = lines[0].Substring(i, 1);
    for (int j = i + 1; j < lines[0].Length && j - i < lines.Length; j++)
    {
        diagonal += lines[j - i].Substring(j, 1);
    }

    count += Regex.Matches(diagonal, "XMAS").Count() + Regex.Matches(diagonal, "SAMX").Count();
}

for (int i = 1; i < lines.Length; i++)
{
    string diagonal = lines[i].Substring(0, 1);
    for (int j = 1; j < lines[0].Length && j + i < lines.Length; j++)
    {
        diagonal += lines[i + j].Substring(j, 1);
    }

    count += Regex.Matches(diagonal, "XMAS").Count() + Regex.Matches(diagonal, "SAMX").Count();
}

// Left Diagonal
for (int i = lines[0].Length - 1; i >= 0; i--)
{
    string diagonal = lines[0].Substring(i, 1);
    for (int j = i - 1; j >= 0 && i - j < lines.Length; j--)
    {
        diagonal += lines[i - j].Substring(j, 1);
    }

    count += Regex.Matches(diagonal, "XMAS").Count() + Regex.Matches(diagonal, "SAMX").Count();
}

for (int i = 1; i < lines.Length; i++)
{
    string diagonal = lines[i].Substring(lines[i].Length - 1);
    for (int j = lines[i].Length - 2; j >= 0 && lines[i].Length - j + i - 1 < lines.Length; j--)
    {
        diagonal += lines[lines[i].Length - j + i - 1].Substring(j, 1);
    }

    count += Regex.Matches(diagonal, "XMAS").Count() + Regex.Matches(diagonal, "SAMX").Count();
}

Console.WriteLine(count);
*/

// Part 2
for (int line = 0; line < lines.Length - 2; line++)
{
    for (int i = 0; i < lines[line].Length - 2; i++)
    {
        string set1 = lines[line].Substring(i, 1) + lines[line + 1].Substring(i + 1, 1) + lines[line + 2].Substring(i + 2, 1);
        string set2 = lines[line + 2].Substring(i, 1) + lines[line + 1].Substring(i + 1, 1) + lines[line].Substring(i + 2, 1);
        if (set1.Equals("MAS") || set1.Equals("SAM"))
        {
            if (set2.Equals("MAS") || set2.Equals("SAM")) count++;
        }
    }
}

Console.WriteLine(count);