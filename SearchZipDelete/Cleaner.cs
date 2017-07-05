using System;
using System.IO;
using System.IO.Compression;
using System.Security.AccessControl;

namespace SearchZipDelete
{
    public class Cleaner : ICleaner
    {

        public ExceptionLogger log { get; protected set; }
        public Searcher search { get; protected set; }
        public DirectoryInfo root { get; protected set; }
        public FileManipulator fileManip { get; protected set; }
        public Writer writer { get; protected set; }
        public bool dirRegistered;
       

        public Cleaner()
        {

            root = new DirectoryInfo("");
            log = new ExceptionLogger();
            writer = new Writer();
            search = new Searcher();
            fileManip = new FileManipulator();
            dirRegistered = false;
           
        }
        public bool RegisterDirectory(string dir) {
            try
            {
                string path = Path.GetFullPath(dir);
                if (Directory.Exists(path))
                {
                    dirRegistered = true;
                }
                else
                    dirRegistered = false;
                return dirRegistered;
            }
            catch (Exception e)
            {
                log.addGeneralException(e);
                return false;
            }

        }
        public void UnregisterDirectory() {
            root = new DirectoryInfo("");
            dirRegistered = false;
        }
        public void CleanDirectory(string dirTo, string identifier) {
            search.WalkDirectoryTree(root, identifier);
            foreach (FileInfo file in search.files)
            {
                try
                {
                    File.Move(file.DirectoryName + "\\" + file.Name, dirTo + "\\" + file.Name);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exeption :: Dint move file :: " + e.Message);
                    log.addGeneralException(e);
                    continue;
                }
            }
        }
        public void ZipDir(string folderName, string identifier) {

        }
        #region Old Code
        /*

        public void InsertCompanyID(string id)
        {
            companyID = id;
        }

        public bool CreateDirectoryWithContext(string path, string fileName)
        {
            try
            {
                DirectorySecurity dSecurity = root.GetAccessControl();

                dSecurity.AddAccessRule(new FileSystemAccessRule("everyone", FileSystemRights.FullControl,
                InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
                root.SetAccessControl(dSecurity);

                Directory.CreateDirectory(path, dSecurity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return CreateTextFileInsideDirectory(path, fileName);

        }
        
         
        bool CreateTextFileInsideDirectory(string folderPathString, string fileName)
        {
            if (!File.Exists(folderPathString))
            {
                try
                {
                    using (FileStream fs = File.Create(folderPathString))
                    {
                        for (byte i = 0; i < 100; i++)
                        {
                            fs.WriteByte(i);
                        }
                    }
                }
                catch (UnauthorizedAccessException e)
                {
                    log.addUnauthorizedException(e);
                }
                catch (Exception e)
                {
                    log.addGeneralException(e);
                }

            }
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", fileName);
                return true;
            }
            
            return false;
        }
        


        void LogAndMoveFileTo(StreamWriter file, FileInfo fi, string folderPathString)
        {
            string writeToFile = " Path: " + fi.DirectoryName + "\\" + fi.Name;
            file.WriteLine(writeToFile);
            //Console.WriteLine(writeToFile);
            if (File.Exists(folderPathString + "\\" + fi.Name) == false)
            {
                try
                {
                    File.Move(fi.DirectoryName + "\\" + fi.Name, folderPathString + "\\" + fi.Name);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exeption :: Dint move file :: " + e.Message);
                    log.addGeneralException(e);
                }
            }
        }

        void CreateZipAndDeleteLeftover(string folderPathString, string zipName)
        {
            //zip
            try
            {
                ZipFile.CreateFromDirectory(folderPathString, zipPath + "\\" + zipName + ".zip");
            }
            catch (Exception e)
            {
                log.addGeneralException(e);
            }

            //delete folder
            Directory.Delete(folderPathString, true);
        }


        
        public void LogAndStoreAllFilesByID()
        {
            //base directory
            //search where userinput is the company id
            search.WalkDirectoryTree(root, companyID);

            //create a folder inside SearchZipDelete named ToBeDeleted: + userinput
            string zipName = "ToBeDeleted_" + companyID;
            string folderPathString = Path.Combine(zipPath, zipName + "\\");
            
            //create text folder inside SearchZipDelete
            string fileName = "DeletedFilesAndPathsOf_" + companyID + ".txt";
            string pathString = Path.Combine(folderPathString, fileName);


            bool fileExists = CreateDirectoryWithContext(folderPathString, fileName);
            
            if(fileExists)
                return;

            StreamWriter file = new StreamWriter(pathString);
            
            //move files to folder and add their details to txt file
            foreach(FileInfo fi in search.files)
            {
                LogAndMoveFileTo(file, fi, folderPathString);
            }

            file.Close();

            CreateZipAndDeleteLeftover(folderPathString, zipName);
            

            
        }      */
        #endregion

    }
    

}
