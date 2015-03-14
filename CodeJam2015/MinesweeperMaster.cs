using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    /// <summary>
    /// Code jam 2014 Qualification round: Problem C
    /// </summary>
    public static class MinesweeperMaster
    {
        public static void DoWork()
        {
            using (var sr = new StreamReader(@"./input.txt"))
            {
                int t = InputReaderHelper.ReadInt(sr);
                for (int i = 0; i < t; i++)
                {
                    Console.WriteLine("Case #{0}:", i + 1);
                    var rcm = InputReaderHelper.ReadInts(sr);

                    if (0 > rcm.LastOrDefault()
                        || rcm.LastOrDefault() >= rcm.FirstOrDefault() * rcm.ToArray()[1])
                    {
                        Console.WriteLine("Impossible");
                        continue;
                    }

                    char[,] board = new char[rcm.FirstOrDefault(),rcm.ToArray()[1]];

                    int mineCount = 0;

                    for (int r = 0; r < rcm.FirstOrDefault(); r++)
                    {
                        for (int c = 0; c < rcm.ToArray()[1]; c++)
                        {
                            if (mineCount < rcm.LastOrDefault())
                            {
                                board[r, c] = '*';
                                Console.Write("*");
                                mineCount++;
                            }
                            else
                            {
                                board[r, c] = '.';
                                Console.Write(".");
                            }
                        }
                        Console.Write(Environment.NewLine);
                    }

                    

                }
            }
        }
    }
}
