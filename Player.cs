using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madu
{
    class Player
    {
        public string Name { get; private set; }
        public int Score { get; private set; }

        public Player(string name)
        {
            Name = name;
            Score = 0;
        }

        public void SetFinalScore(int score)
        {
            Score = score;
        }

        
        public void SaveResult()
        {
            string fileName = "GameResults.txt";
            string result = $"{Name}:{Score}";

            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(result);
            }
        }

        
        public static void DisplayResults()
        {
            string fileName = "GameResults.txt";
            if (File.Exists(fileName))
            {
                var lines = File.ReadAllLines(fileName);
                var sortedLines = lines
                    .Select(line => line.Split(':'))
                    .Where(parts => parts.Length == 2)
                    .OrderByDescending(parts => int.Parse(parts[1]))
                    .Select(parts => $"{parts[0]}: {parts[1]}")
                    .ToList();
                foreach (var line in sortedLines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("tulemusi veel pole.");
            }
        }
    }
}