using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchZipDelete
{
    class ReportsManager
    {

        public Searcher searcher { get; protected set; }
        public Writer writer { get;  protected set;}
        public FileManipulator fileManip { get; protected set; }

        

        public ReportsManager()
        {
            searcher = new Searcher();
            writer = new Writer();
            fileManip = new FileManipulator();
            
        }

        public void RegisterReport(int reportID)
        {

        }


    }
}
