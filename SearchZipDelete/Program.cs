using System;

namespace SearchZipDelete
{
    class Program
    {
        static void Main(string[] args)
        {
            FileManipulation szd = new FileManipulation();
            szd.manipulate();

            Console.ReadKey();
        }
    }
}
