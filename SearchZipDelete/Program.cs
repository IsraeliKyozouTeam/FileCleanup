using System;

namespace SearchZipDelete
{
    class Program
    {
        static void Main(string[] args)
        {

            int id = 0;

            Cleaner cleaner = new Cleaner(@"C:\Users\Sean\Desktop\FileCleanup-TestBranch\Test", @"C:\Users\Sean\Desktop\FileCleanup-TestBranch");

            FileDataSet ds = new FileDataSet();
            DataAccessObject dao = new DataAccessObject();

            ds.TCDB_FilesToDelete.Rows.Add(dao.getCompanyInfo(id));

            cleaner.CreateDirectoryWithContext(@"C:\Users\Sean\Desktop\FileCleanup-TestBranch", "folder");



        }
    }
}
