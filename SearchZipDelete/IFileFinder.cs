using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchZipDelete
{
    public interface IFileFinder
    {

        // The writer should have some sort of list that holds all the current paths we 
        // want to work with. As such the pathList should be able to add and remove paths.
        // Adding the path to the pathList should check whether the path is valid and if not
        // return false.

        bool AddPathToPathList(string path);

        void RemovePathFromPathList(string path);


        // The writer should be able to manipulate files and delete all of the files in given paths
        void DeleteAllFilesInPaths();


        // The writer brings all the files in its pathList to a given path
        // It should check whether the path is valid and if not return false
        // and not run at all.
        void ConcentrateFilesInPathsTo(string pathTo);
    }
}
