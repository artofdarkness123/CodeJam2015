using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifierProb3Dijkstra
{
    public static class InputReaderHelper
    {
        public static int ReadInt(TextReader sr)
        {
            return Int32.Parse(sr.ReadLine());
        }
        
        public static IEnumerable<int> ReadInts(TextReader sr)
        {
            return ReadLineSplit(sr).Select(i => Int32.Parse(i));
        }

        public static ulong ReadULong(TextReader sr)
        {
            return UInt64.Parse(sr.ReadLine());
        }

        public static IEnumerable<ulong> ReadULongs(TextReader sr)
        {
            return ReadLineSplit(sr).Select(i => UInt64.Parse(i));
        }

        public static IEnumerable<string> ReadLineSplit(TextReader sr)
        {
            return sr.ReadLine().Split(' ');
        }

        public static void SkipLines(TextReader sr, int count)
        {
            for (int i = 0; i < count; i++)
                sr.ReadLine();
        }
    }
}
