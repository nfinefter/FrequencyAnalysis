using System;
using System.Collections.Generic;
using System.IO;

namespace FrequencyAnalysis
{
    class Program
    {
        // "Hello" -> "0.1.2.2.3"
        // "Jello" -> "0.1.2.2.3"

        static string FrequencyAnalysis(string input)
        {
            Dictionary<char, int> letterIndices = new Dictionary<char, int>();
            string encryptedMsg = "";

            int count = -1;

            for (int i = 0; i < input.Length; i++)
            {

                if (!letterIndices.ContainsKey(input[i]))
                {
                    count++;
                    letterIndices.Add(input[i], count);
                }
        

                encryptedMsg += letterIndices[input[i]] + ".";
            }

            return encryptedMsg;
        }
        static Dictionary<string, List<string>> LoadWords(string[] dictionary)
        {
            Dictionary<string, List<string>> PossibleWords = new Dictionary<string, List<string>>();
            List<string> combinations = new List<string>();

            for (int i = 0; i < dictionary.Length; i++)
            {
                if (!combinations.Contains(FrequencyAnalysis(dictionary[i])))
                {
                    combinations.Add(FrequencyAnalysis(dictionary[i]));
                    PossibleWords.Add(FrequencyAnalysis(dictionary[i]), combinations);
                }

            }

            return PossibleWords;
        }

        static void Main(string[] args)
        {
            // "0.1.2.2.3" -> { Hello, Jello, ... }
            // "0.1.2.3.4" -> { Smart, Catch, ... }

            string[] dictionary = File.ReadAllLines("dictionary.txt");
            
            //Console.WriteLine("Give String!");
            //string input = Console.ReadLine();
            //Console.WriteLine(FrequencyAnalysis(input));

            Console.WriteLine(LoadWords(dictionary));
        }
    }
}
