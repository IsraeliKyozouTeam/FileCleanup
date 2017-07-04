using System;
using System.IO;
using System.IO.Compression;
using System.Security.AccessControl;

namespace SearchZipDelete
{
    public class Cleaner
    {

        public ExceptionLogger log { get; protected set; }
        public Search search { get; protected set; }
        public DirectoryInfo root { get; protected set; }

        public string companyID { get; protected set; }
        public string zipPath { get; protected set; }

        public Cleaner(string rootFolder, string zipPath)
        {

            root = new DirectoryInfo(rootFolder);
            log = new ExceptionLogger();
            
            search = new Search();

            this.zipPath = zipPath = @"C:\Users\guyb2\Desktop\SearchZipDelete\";
        }

        public void InsertCompanyID(string id)
        {
            companyID = id;
        }

        public void CreateDirectoryWithContext(string path, string fileName)
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

            CreateTextFileInsideDirectory(path, fileName);

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
        
        void CreateTextFileInsideDirectory(string folderPathString, string fileName)
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



        public void Manipulate() {
            //base directory
            //search where userinput is the company id
            search.WalkDirectoryTree(root, companyID);

            //create a folder inside SearchZipDelete named ToBeDeleted: + userinput
            string zipName = "ToBeDeleted_" + companyID;
            string folderPathString = Path.Combine(zipPath, zipName + "\\");
            
            //create text folder inside SearchZipDelete
            string fileName = "DeletedFilesAndPathsOf_" + companyID + ".txt";
            string pathString = Path.Combine(folderPathString, fileName);


            CreateDirectoryWithContext(folderPathString, fileName);

            StreamWriter file = new StreamWriter(pathString);
            
            //move files to folder and add their details to txt file
            foreach(FileInfo fi in search.files)
            {
                LogAndMoveFileTo(file, fi, folderPathString);
            }

            file.Close();

            CreateZipAndDeleteLeftover(folderPathString, zipName);
            

            
        }      
                       
    }
    

}
