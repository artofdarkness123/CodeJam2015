using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifierProb1StandingOvation
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sr = new StreamReader(@"C:\Users\svona\Downloads\A-large.in"))
            {
                using (var wr = new StreamWriter(@"done.txt"))
                {
                    int t = InputReaderHelper.ReadInt(sr);
                    for (int i = 0; i < t; i++)
                    {
                        string config = InputReaderHelper.ReadLineSplit(sr).LastOrDefault();
                        var sArray = config.Select(b => Int32.Parse(b.ToString())).ToList();

                        int addCount = 0;

                        for (int j = 1; j < sArray.Count; j++)
                        {
                            var takeList = sArray.Take(j);
                            int runningSum = takeList.Sum();

                            if (runningSum < j)
                            {
                                int temp = j - runningSum;
                                addCount += temp;
                                sArray[j] += temp;
                            }
                        }

                        Console.WriteLine("Case #{0}: {1}", i + 1, addCount);
                        wr.WriteLine("Case #{0}: {1}", i + 1, addCount);
                    }
                }

                Console.WriteLine("DONE");
                Console.ReadKey();
            }
        }
    }
}
