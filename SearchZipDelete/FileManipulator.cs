using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchZipDelete
{
    public class FileManipulator : IFileFinder
    {
        //List of all paths connected to this finder
        public List<string> pathList { get; protected set; }

        // Method that adds a new path to the list, probably important to make sure its viable
        // return true if the path can be added to the list and is viable, return false if the path
        // does not exist.
        public bool AddPathToPathList(string path)
        {
            return false;
        }



        // Go through all current paths listed in pathlist and move the files to the given path
        // -Important to make sure the path exists and if not to create the path 
        public void ConcentrateFilesInPathsTo(string pathTo)
        {
            
        }

        // Go through all current paths listed in pathlist and delete files in given path
        public void DeleteAllFilesInPaths()
        {

        }

        public void DeleteAllFilesInGivenPath(string path)
        {

        }

        // Goes through all currentPaths listed in pathlist and zips them in a given path
        public void zipFile(string pathTo)
        {
            ConcentrateFilesInPathsTo(pathTo + "\\test");




            DeleteAllFilesInGivenPath(pathTo + "\\test");
        }

    }
}
