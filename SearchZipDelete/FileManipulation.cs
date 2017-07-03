using System;
using System.IO;
using System.IO.Compression;
using System.Security.AccessControl;

namespace SearchZipDelete
{
    public class FileManipulation
    {
        public void manipulate() {
            ExceptionLogger log = new ExceptionLogger();
            //base directory
            DirectoryInfo root = new DirectoryInfo(@"C:\Users\guyb2\Desktop\TestDeletionScript");
            //search where userinput is the company id
            Search search = new Search();
            Console.WriteLine("enter company id");

            string userInput = Console.ReadLine();
            

            search.WalkDirectoryTree(root, userInput);
            //create a folder inside SearchZipDelete named ToBeDeleted: + userinput
            string folderName = @"C:\Users\guyb2\Desktop\SearchZipDelete\";
            string zipName = "ToBeDeleted_" + userInput;
            string folderPathString = Path.Combine(folderName, zipName + "\\");
            try
            {
                DirectorySecurity dSecurity = root.GetAccessControl();

                dSecurity.AddAccessRule(new FileSystemAccessRule("everyone", FileSystemRights.FullControl,
                InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
                root.SetAccessControl(dSecurity);

                Directory.CreateDirectory(folderPathString, dSecurity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //create text folder inside SearchZipDelete
            string fileName = "DeletedFilesAndPathsOf_"+userInput+".txt";
            string pathString = Path.Combine(folderPathString, fileName);
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
                return;               
            }

            StreamWriter file = new StreamWriter(pathString);

            
            //move files to folder and add their details to txt file
            foreach(FileInfo fi in search.files)
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
                        continue;
                    }
                }
            }

            file.Close();

            
            //zip
            try
            {
            ZipFile.CreateFromDirectory(folderPathString, folderName + "\\" + zipName + ".zip");
            }
            catch(Exception e)
            {
                log.addGeneralException(e);
            }

            //delete folder
            Directory.Delete(folderPathString, true);

            
        }      
                       
    }
    

}
