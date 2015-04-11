using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifierProb1StandingOvation
{
    public static class InputReaderHelper
    {
        public static int ReadInt(StreamReader sr)
        {
            return Int32.Parse(sr.ReadLine());
        }

        public static IEnumerable<int> ReadInts(StreamReader sr)
        {
            return ReadLineSplit(sr).Select(i => Int32.Parse(i));
        }

        public static ulong ReadULong(StreamReader sr)
        {
            return UInt64.Parse(sr.ReadLine());
        }

        public static IEnumerable<ulong> ReadULongs(StreamReader sr)
        {
            return ReadLineSplit(sr).Select(i => UInt64.Parse(i));
        }

        public static IEnumerable<string> ReadLineSplit(StreamReader sr)
        {
            return sr.ReadLine().Split(' ');
        }

        public static void SkipLines(StreamReader sr, int count)
        {
            for (int i = 0; i < count; i++)
                sr.ReadLine();
        }
    }
}
