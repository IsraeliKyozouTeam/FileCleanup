using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchZipDelete
{
    interface ICleaner
    {
        // Recieves a path to a directory for the cleaner to focus on. This function saves the
        // directory to a property and uses it for the following functions. It returns true if the
        // dir is valid and false if not.
        bool RegisterDirectory(string dir);
        void UnregisterDirectory();

        // This function recieves a directory and cleans it by taking all the files
        // identified by the identifier and moves them to the specified dirTo.
        void CleanDirectory(string dirTo, string identifier);

        // Zips a specified folder in the specified directory
        void ZipDir(string folderName, string identifier);
        
    }
}
