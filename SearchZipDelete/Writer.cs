using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace SearchZipDelete
{
    public class Writer : IWriter
    {
        StreamWriter writer;
        bool pathRegistered;

        public Writer()
        {
            pathRegistered = false;
        }

        public void RegisterPath(string path)
        {
            writer = new StreamWriter(path);
            pathRegistered = true;
        }

        public void WriteLineToPath(string line)
        {
            if (pathRegistered)
            {
                try
                {
                    writer.WriteLine(line);
                }
                catch (Exception)
                {

                }
            }
        }

        public void NextLine()
        {
            WriteLineToPath("");
        }

        public void Close()
        {
            writer.Close();
        }

    }
}
