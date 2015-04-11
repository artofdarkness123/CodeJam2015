using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifierProb3Dijkstra
{
    class Program
    {
        public static Dictionary<Tuple<string, string>, string> key = new Dictionary<Tuple<string, string>, string>();

        static void Main(string[] args)
        {
            Program.key.Add(Tuple.Create<string, string>("-1", "-1"), "1");
            Program.key.Add(Tuple.Create<string, string>("-1", "-i"), "i");
            Program.key.Add(Tuple.Create<string, string>("-1", "-j"), "j");
            Program.key.Add(Tuple.Create<string, string>("-1", "-k"), "k");
            Program.key.Add(Tuple.Create<string, string>("-1", "1"), "-1");
            Program.key.Add(Tuple.Create<string, string>("-1", "i"), "-i");
            Program.key.Add(Tuple.Create<string, string>("-1", "j"), "-j");
            Program.key.Add(Tuple.Create<string, string>("-1", "k"), "-k");

            Program.key.Add(Tuple.Create<string, string>("-i", "-1"), "i");
            Program.key.Add(Tuple.Create<string, string>("-i", "-i"), "-1");
            Program.key.Add(Tuple.Create<string, string>("-i", "-j"), "k");
            Program.key.Add(Tuple.Create<string, string>("-i", "-k"), "-j");
            Program.key.Add(Tuple.Create<string, string>("-i", "1"), "-i");
            Program.key.Add(Tuple.Create<string, string>("-i", "i"), "1");
            Program.key.Add(Tuple.Create<string, string>("-i", "j"), "-k");
            Program.key.Add(Tuple.Create<string, string>("-i", "k"), "j");

            Program.key.Add(Tuple.Create<string, string>("-j", "-1"), "j");
            Program.key.Add(Tuple.Create<string, string>("-j", "-i"), "-k");
            Program.key.Add(Tuple.Create<string, string>("-j", "-j"), "-1");
            Program.key.Add(Tuple.Create<string, string>("-j", "-k"), "i");
            Program.key.Add(Tuple.Create<string, string>("-j", "1"), "-j");
            Program.key.Add(Tuple.Create<string, string>("-j", "i"), "k");
            Program.key.Add(Tuple.Create<string, string>("-j", "j"), "1");
            Program.key.Add(Tuple.Create<string, string>("-j", "k"), "-i");

            Program.key.Add(Tuple.Create<string, string>("-k", "-1"), "k");
            Program.key.Add(Tuple.Create<string, string>("-k", "-i"), "j");
            Program.key.Add(Tuple.Create<string, string>("-k", "-j"), "-i");
            Program.key.Add(Tuple.Create<string, string>("-k", "-k"), "-1");
            Program.key.Add(Tuple.Create<string, string>("-k", "1"), "-k");
            Program.key.Add(Tuple.Create<string, string>("-k", "i"), "-j");
            Program.key.Add(Tuple.Create<string, string>("-k", "j"), "i");
            Program.key.Add(Tuple.Create<string, string>("-k", "k"), "1");

            Program.key.Add(Tuple.Create<string, string>("1", "-1"), "-1");
            Program.key.Add(Tuple.Create<string, string>("1", "-i"), "-i");
            Program.key.Add(Tuple.Create<string, string>("1", "-j"), "-j");
            Program.key.Add(Tuple.Create<string, string>("1", "-k"), "-k");
            Program.key.Add(Tuple.Create<string, string>("1", "1"), "1");
            Program.key.Add(Tuple.Create<string, string>("1", "i"), "i");
            Program.key.Add(Tuple.Create<string, string>("1", "j"), "j");
            Program.key.Add(Tuple.Create<string, string>("1", "k"), "k");

            Program.key.Add(Tuple.Create<string, string>("i", "-1"), "-i");
            Program.key.Add(Tuple.Create<string, string>("i", "-i"), "1");
            Program.key.Add(Tuple.Create<string, string>("i", "-j"), "-k");
            Program.key.Add(Tuple.Create<string, string>("i", "-k"), "j");
            Program.key.Add(Tuple.Create<string, string>("i", "1"), "i");
            Program.key.Add(Tuple.Create<string, string>("i", "i"), "-1");
            Program.key.Add(Tuple.Create<string, string>("i", "j"), "k");
            Program.key.Add(Tuple.Create<string, string>("i", "k"), "-j");

            Program.key.Add(Tuple.Create<string, string>("j", "-1"), "-j");
            Program.key.Add(Tuple.Create<string, string>("j", "-i"), "k");
            Program.key.Add(Tuple.Create<string, string>("j", "-j"), "1");
            Program.key.Add(Tuple.Create<string, string>("j", "-k"), "-i");
            Program.key.Add(Tuple.Create<string, string>("j", "1"), "j");
            Program.key.Add(Tuple.Create<string, string>("j", "i"), "-k");
            Program.key.Add(Tuple.Create<string, string>("j", "j"), "-1");
            Program.key.Add(Tuple.Create<string, string>("j", "k"), "i");

            Program.key.Add(Tuple.Create<string, string>("k", "-1"), "-k");
            Program.key.Add(Tuple.Create<string, string>("k", "-i"), "-j");
            Program.key.Add(Tuple.Create<string, string>("k", "-j"), "i");
            Program.key.Add(Tuple.Create<string, string>("k", "-k"), "1");
            Program.key.Add(Tuple.Create<string, string>("k", "1"), "k");
            Program.key.Add(Tuple.Create<string, string>("k", "i"), "j");
            Program.key.Add(Tuple.Create<string, string>("k", "j"), "-i");
            Program.key.Add(Tuple.Create<string, string>("k", "k"), "-1");

            using (var sr = new StreamReader(@"./input.txt"))
            {
                using (var wr = new StreamWriter(@"done.txt"))
                {
                    int t = InputReaderHelper.ReadInt(sr);
                    for (int i = 0; i < t; i++)
                    {
                        int x = InputReaderHelper.ReadInts(sr).LastOrDefault();
                        string str  = String.Empty;
                        string temp = sr.ReadLine();

                        for (int j = 0; j < x; j++)
                        {
                            str += temp;
                        }

                        using (var sReader = new StringReader(str))
                        {
                            if (PassTest(sReader, "i") && PassTest(sReader, "j") && PassK(sReader))
                            {
                                Console.WriteLine("Case #{0}: {1}", i + 1, "YES");
                            }
                            else
                            {
                                Console.WriteLine("Case #{0}: {1}", i + 1, "NO");
                            }
                        }

                        // System.Diagnostics.Debug.WriteLine(str);

                        //Console.WriteLine("Case #{0}: {1}", i + 1, "NO");
                        //wr.WriteLine("Case #{0}: {1}", i + 1, "YES");
                    }
                }
            }

            Console.WriteLine("DONE");
            Console.ReadKey();
        }

        private static bool PassTest(StringReader sReader, string character)
        {
            int charInt;
            string tempStr = String.Empty;
            string bleh;

            charInt = sReader.Read();
            if (charInt == -1)
                return false;
            else
                tempStr = ((char)charInt).ToString();

            if (String.Equals(tempStr, character, StringComparison.OrdinalIgnoreCase))
                return true;
            
            do
            {
                charInt = sReader.Read();
                if (charInt == -1)
                    return false;
                else
                    bleh = ((char)charInt).ToString();
                    
                if (String.IsNullOrWhiteSpace(tempStr))
                {
                    bleh = ((char)charInt).ToString();
                    tempStr = bleh;
                }

                if (String.Equals(tempStr, character, StringComparison.OrdinalIgnoreCase))
                    return true;
                else
                {
                    tempStr = Program.key[Tuple.Create<string, string>(tempStr, bleh)];
                }
            }
            while (charInt != -1);

            return false; // String.Equals(tempStr, character, StringComparison.OrdinalIgnoreCase);
        }

        private static bool PassK(StringReader sReader)
        {
            int charInt;
            string tempStr = String.Empty;
            string bleh;

            charInt = sReader.Read();
            if (charInt == -1)
                goto myLabel;
            else
                tempStr = ((char)charInt).ToString();
            
            do
            {
                charInt = sReader.Read();
                if (charInt == -1)
                    goto myLabel;
                else
                    bleh = ((char)charInt).ToString();

                if (String.IsNullOrWhiteSpace(tempStr))
                {
                    bleh = ((char)charInt).ToString();
                    tempStr = bleh;
                }

                tempStr = Program.key[Tuple.Create<string, string>(tempStr, bleh)];
            }
            while (charInt != -1);
            
            myLabel:
            return tempStr == "k";
        }

        /*
        string Program.keyStr = @"1 i j k -1 -i -j -k
1 1 i j k -1 -i -j -k
i i -1 k -j -i 1 -k j
j j -k -1 i -j k 1 -i
k k j -i -1 -k -j i 1
-1 -1 -i -j -k 1 i j k
-i -i 1 -k j i -1 k -j
-j -j k 1 -i j -k -1 i
-k -k -j i 1 k j -i -1";



        string[][] array = new string[9][];

        TextReader sr = new StringReader(Program.keyStr);
        for (int i = 0; i < 9; i++)
        {
            array[i] = InputReaderHelper.ReadLineSplit(sr).ToArray();
        }
            
        sr.Close();


        var temp = array[8][8];

        // Console.WriteLine(temp);

        var table = new Dictionary<Tuple<string, string>, string>();

        for (int x = 1; x < array.Length; x++)
        {
            for (int y = 1; y < array[x].Length; y++)
            {
                // Console.Write(array[x][y] + " ");

                if (!table.ContainsProgram.key(Tuple.Create<string, string>(array[x - 1][0], array[0][y - 1])))
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("[{0}][{1}] = {2}", array[x - 1][0], array[0][y - 1], array[x][y]));
                    table.Add(Tuple.Create<string, string>(array[x - 1][0], array[0][y - 1]), array[x][y]);
                }
            }

            Console.WriteLine();
        }
        */
    }
}
