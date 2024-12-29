using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

string[] text = File.ReadAllText("..\\..\\..\\Data.txt").Split("\r\n");
List<int> list1 = new List<int>();
List<int> list2 = new List<int>();
int sum = 0;
int simScore = 0;

for (int i = 0; i < text.Length; i++)
{
    list1.Add(int.Parse(text[i].Substring(0, 5)));
    list2.Add(int.Parse(text[i].Substring(8)));
}

list1.Sort();
list2.Sort();

for (int i = 0; i < list1.Count; i++)
{
    sum += Math.Abs(list2[i] - list1[i]);
    simScore += list1[i] * list2.Count(x => x == list1[i]);
}

Console.WriteLine("Sum of differences: " + sum);
Console.WriteLine("Similarity score: " + simScore);