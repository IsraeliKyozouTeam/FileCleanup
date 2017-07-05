using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SearchZipDelete
{
    interface IWriter
    {


        void RegisterPath(string path);

        // Give the writeTo a path and it will write a the line of text to the given file
        // - should also check whether the file is valid.
        void WriteLineToPath(string line);


       
    }
}
