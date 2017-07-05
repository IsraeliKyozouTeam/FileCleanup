using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SearchZipDelete
{
    class FileFinder : IFileFinder
    {
        ExceptionLogger log;
        List<string> PathList;
        public FileFinder()
        {
            log = new ExceptionLogger();
            PathList = new List<string>();
        }
        public bool AddPathToPathList(string path)
        {
            if (Uri.IsWellFormedUriString(path, UriKind.Absolute))
            {
                if (!PathList.Contains(path))
                {
                    PathList.Add(path);
                }

                return true;
            }
            else
                return false;
        }
        public void RemovePathFromPathList(string path) {
            if (PathList.Contains(path))
                PathList.Remove(path);
        }

        public void DeleteAllFilesInPaths()
        {
            foreach (string path in PathList)
            {
                try
                {
                    DirectoryInfo di = new DirectoryInfo(path);

                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }
                }
                catch (UnauthorizedAccessException e)
                {
                    log.addUnauthorizedException(e);
                }
                catch (DirectoryNotFoundException e)
                {
                    log.addDirectoryException(e);
                }
                catch (Exception e)
                {
                    log.addGeneralException(e);
                }

            }
        }
        public void ConcentrateFilesInPathsTo(string pathTo) {
            foreach (string path in PathList) {
                try
                {
                    DirectoryInfo di = new DirectoryInfo(path);
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.MoveTo(pathTo);
                    }
                }
                catch (UnauthorizedAccessException e) {
                    log.addUnauthorizedException(e);
                }
                catch (DirectoryNotFoundException e)
                {
                    log.addDirectoryException(e);
                }
                catch (Exception e)
                {
                    log.addGeneralException(e);
                }
            }
        }
            
    }
}

