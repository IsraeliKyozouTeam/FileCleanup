using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchZipDelete
{
    class Manipulator
    {

        public Searcher searcher { get; protected set; }
        public Writer writer { get;  protected set;}
        public FileManipulator fileManip { get; protected set; }

        

        public Manipulator()
        {
            searcher = new Searcher();
            writer = new Writer();
            fileManip = new FileManipulator();
            
        }

        public void RegisterURL(string url)
        {

        }


    }
}
