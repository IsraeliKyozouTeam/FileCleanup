using System;

namespace SearchZipDelete
{
    class Program
    {
        static void Main(string[] args)
        {

            ReportsManager rm = new ReportsManager();

            string pathToID = @"C:\Users\roysh_000\Desktop\TestDir\Reports2";

            rm.RegisterIDFromFile(pathToID);

            rm.WriteDiscrpeneciesToFile(@"C:\Users\roysh_000\Desktop\TestDir\Disc.txt");



        }
    }
}
