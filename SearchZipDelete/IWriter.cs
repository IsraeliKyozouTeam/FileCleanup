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
        // The writers should have one string that holds all the text that they should write
        // and as such need two functions to add and remove text from the write text.
        void AddToWrite(string text);

        void RemoveFromWrite(string text);


        // Give the writeTo a path and it will write all the text it is holding on to the given file
        // - should also check whether the file is valid.
        void WriteTo(string path);


       
    }
}
