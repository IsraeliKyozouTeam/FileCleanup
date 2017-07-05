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

        void AddToWrite(string text);

        void WriteTo(string path);

        void RemoveFromWrite(string text);

       
    }
}
