using System;
using System.Linq;

namespace statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] data = {
                {"StdNum", "Name", "Math", "Science", "English"},
                {"1001", "Alice", "85", "90", "78"},
                {"1002", "Bob", "92", "88", "84"},
                {"1003", "Charlie", "79", "85", "88"},
                {"1004", "David", "94", "76", "92"},
                {"1005", "Eve", "72", "95", "89"}
            };
            // You can convert string to double by
            // double.Parse(str)

            int stdCount = data.GetLength(0) - 1;
            int SubCount = data.GetLength(1) - 2;
            double sum_math = 0, sum_sci = 0, sum_eng = 0;
            double max_math = 0, max_sci = 0, max_eng = 0;
            double min_math = 100, min_sci = 100, min_eng = 100;

            double Alice = 0, Bob = 0, Charlie = 0, David = 0, Eve = 0;

            for (int i = 0; i < SubCount; i++)
            {
                Alice += double.Parse(data[1, i + 2]);
                Bob += double.Parse(data[2, i + 2]);
                Charlie += double.Parse(data[3, i + 2]);
                David += double.Parse(data[4, i + 2]);
                Eve += double.Parse(data[5, i + 2]);
            }

            double[] totalscores = { Alice, Bob, Charlie, David, Eve };
            int[] rankings = Enumerable.Repeat(1, stdCount).ToArray();
            string[] rank = { "1st", "2nd", "3rd", "4th", "5th" };


            for (int j = 1; j <= stdCount; j++)
            {
                sum_math += double.Parse(data[j, 2]);
                sum_sci += double.Parse(data[j, 3]);
                sum_eng += double.Parse(data[j, 4]);

                max_math = max_math < double.Parse(data[j, 2]) ? double.Parse(data[j, 2]) : max_math;
                max_sci = max_sci < double.Parse(data[j, 3]) ? double.Parse(data[j, 3]) : max_sci;
                max_eng = max_eng < double.Parse(data[j, 4]) ? double.Parse(data[j, 4]) : max_eng;

                min_math = min_math > double.Parse(data[j, 2]) ? double.Parse(data[j, 2]) : min_math;
                min_sci = min_sci > double.Parse(data[j, 3]) ? double.Parse(data[j, 3]) : min_sci;
                min_eng = min_eng > double.Parse(data[j, 4]) ? double.Parse(data[j, 4]) : min_eng;

                rankings[j-1] = stdCount;
                for (int k = 0; k < totalscores.Length; k++)
                {
                    if (totalscores[j-1] > totalscores[k])
                    {
                        rankings[j - 1]--;
                    }
                }
            }
            double avg_math = sum_math / stdCount;
            double avg_sci = sum_sci / stdCount;
            double avg_eng = sum_eng / stdCount;
            
            Console.WriteLine("Average Scores: \nMath: {0:n}\nScience: {1:n}\nEnglish: {2:n}\n\nMax and min Scores: \nMath: ({3}, {4})\nScience: ({5}, {6})\nEnglish: ({7}, {8})\n\nStudents rank by total scores:\nAlice: {9}\nBob: {10}\nCharlie: {11}\nDavid: {12}\nEve: {13}", avg_math, avg_sci, avg_eng, max_math, min_math, max_sci, min_sci, max_eng, min_eng, rank[rankings[0]-1], rank[rankings[1]-1], rank[rankings[2] - 1], rank[rankings[3] - 1], rank[rankings[4] - 1]);
        }
    }
}

/* example output

Average Scores: 
Math: 84.40
Science: 86.80
English: 86.20

Max and min Scores: 
Math: (94, 72)
Science: (95, 76)
English: (92, 78)

Students rank by total scores:
Alice: 2nd
Bob: 5th
Charlie: 1st
David: 4th
Eve: 3rd

*/
