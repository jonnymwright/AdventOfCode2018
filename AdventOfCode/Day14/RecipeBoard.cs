using System;
using System.Collections.Generic;
using System.Linq;

namespace jonny.AoC.Day14
{

    public class RecipeBoard
    {
        public List<int> Board { get; }

        private int elf1;
        private int elf2;
        public RecipeBoard(IEnumerable<int> initialRecipies)
        {
            elf1 = 0; elf2 = 1;
            Board = new List<int>(initialRecipies);
        }

        public void Cook()
        {
            CookWithCallback((_) => {});
        }

        public string Score(int practices) {
            while(Board.Count < practices + 10) {
                Cook();
            }
            var scores = Board.Skip(practices).Take(10);
            var result = string.Concat(scores);
            return result;
        }

        public int BeforeScore(string score) {
            bool found = false;
            int result = 2;
            int match = 0;
            Action<IEnumerable<int>> callback = (toAdd) => {
                foreach(int add in toAdd) {
                    if (match == score.Length) {
                        result -= score.Length;
                        found = true;
                        break;
                    } else if (score[match] - '0' == add) {
                        match++;
                        result++;
                    } else {
                        match = 0;
                        result++;
                    }
                }
            };
            while (!found) {
                CookWithCallback(callback);
            }
            return result;
        }

        private void CookWithCallback(Action<IEnumerable<int>> callback) {
            var next = Board[elf1] + Board[elf2];
            List<int> toAdd = new List<int>();
            do
            {
                toAdd.Add(next % 10);
                next /= 10;
            } while (next > 0);
            toAdd.Reverse();
            callback(toAdd);
            Board.AddRange(toAdd);
            elf1 = (elf1 + Board[elf1] + 1) % Board.Count();
            elf2 = (elf2 + Board[elf2] + 1) % Board.Count();
        }
    }
}