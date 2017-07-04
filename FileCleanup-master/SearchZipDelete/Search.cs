using System;
using System.IO;
using System.Collections.Generic;

namespace SearchZipDelete
{
    public class Search
    {
        public List<FileInfo> files = new List<FileInfo>();
        public void WalkDirectoryTree(System.IO.DirectoryInfo root, string companyID)
        {
            ExceptionLogger log = new ExceptionLogger();
            System.IO.DirectoryInfo[] subDirs = null;

            // First, process all the files directly under this folder 
            try
            {                
                FileInfo[] filesToAdd = root.GetFiles("*" + companyID + "*.*");

                foreach (FileInfo fi in filesToAdd)
                {
                    if (files.Contains(fi) == false)
                        files.Add(fi);
                }
            }
            // This is thrown if even one of the files requires permissions greater 
            // than the application provides. 
            catch (UnauthorizedAccessException e)
            {
                
                log.addUnauthorizedException(e);
                
                
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                log.addDirectoryException(e);
            }

            if (files != null)
            {
                int i = 0;

                /*
                foreach (System.IO.FileInfo fi in files)
                {                   
                    Console.WriteLine(fi.FullName);
                    i++;
                }*/
                

                // Now find all the subdirectories under this directory.
                try
                {
                    subDirs = root.GetDirectories();
                    foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                    {
                        // Resursive call for each subdirectory.
                        WalkDirectoryTree(dirInfo, companyID);
                    }
                }
                catch (UnauthorizedAccessException e)
                {
                    log.addUnauthorizedException(e);
                }
                catch (System.IO.DirectoryNotFoundException e)
                {
                    log.addDirectoryException(e);
                }
                catch (NotSupportedException e)
                {
                    log.addGeneralException(e);
                }
                catch (Exception e) {
                    log.addGeneralException(e);
                }
               
            }
        }
    }
}
