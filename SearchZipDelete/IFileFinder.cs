using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchZipDelete
{
    public interface IFileFinder
    {
        bool AddPathToPathList(string path);
    
        void DeleteAllFilesInPaths();
    
        void ConcentrateFilesInPathsTo(string pathTo);
    }
}
