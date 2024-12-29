using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

string[] text = File.ReadAllText("..\\..\\..\\Data.txt").Split("\r\n");
int safeCount = 0;

foreach (string s in text)
{
    List<int> nums = s.Split(" ").Select(int.Parse).ToList();

    // Check if the original sequence is safe
    if (IsSafe(nums))
    {
        safeCount++;
        continue;
    }

    // Try removing each level and check if it becomes safe
    bool foundSafe = false;
    for (int i = 0; i < nums.Count; i++)
    {
        List<int> modified = new List<int>(nums);
        modified.RemoveAt(i);
        if (IsSafe(modified))
        {
            foundSafe = true;
            break;
        }
    }

    if (foundSafe)
    {
        safeCount++;
    }
}

Console.WriteLine(safeCount);

bool IsSafe(List<int> nums)
{
    if (nums.Count < 2) return false;

    bool increasing = nums[1] > nums[0];
    for (int i = 1; i < nums.Count; i++)
    {
        int diff = nums[i] - nums[i - 1];
        if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3 || (diff > 0 != increasing))
        {
            return false;
        }
    }
    return true;
}