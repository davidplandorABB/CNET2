﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    public class TextTools
    {
        public static Dictionary<string, int> FreqAnalysis(string file)
        {
            var content = File.ReadAllText(file);
            var words = content.Split(' ');

            Dictionary<string, int> dict = new();

            foreach (var word in words)
            {
                if (string.IsNullOrWhiteSpace(word))
                    continue;

                if(dict.ContainsKey(word))
                {
                    dict[word]++;
                }
                else
                {
                    dict.Add(word, 1);
                }
            }

            return dict;
        }

        public static Dictionary<string, int> GetTopWords(int takeTop, Dictionary<string, int> dict)
        {
            return dict
                .OrderByDescending(x => x.Value).Take(takeTop)
                .ToDictionary(x => x.Key, y => y.Value);
                ;
        }
    }
}
