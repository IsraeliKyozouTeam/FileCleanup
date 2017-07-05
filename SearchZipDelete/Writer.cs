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

        string textToWrite;

        public Writer(string textToWrite = "")
        {
            this.textToWrite = textToWrite;
        }

        public void AddToWrite(string text)
        {
            textToWrite += text;
        }

        public void RemoveFromWrite(string text)
        {
            textToWrite = Regex.Replace(textToWrite, text, "");
        }

        public void WriteTo(string path)
        {
            
            if (Uri.IsWellFormedUriString(path, UriKind.Absolute))
            {
                StreamWriter writer = new StreamWriter(path);
                writer.Write(textToWrite);
                writer.Close();
            }
        }
    }
}
