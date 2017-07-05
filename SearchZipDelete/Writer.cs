using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace SearchZipDelete
{
    class Writer : IWriter
    {
        

        public Writer()
        {
        }
        

        public void WriteLineTo(string path, string line)
        {

            try
            {
                StreamWriter writer = new StreamWriter(path);
                writer.WriteLine(line);
                writer.Close();
            }
            catch (Exception)
            {
                
            }
                
        }

    }
}
