using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchZipDelete
{
    class ReportsManager
    {

        public Searcher searcher { get; protected set; }
        public Writer writer { get;  protected set;}
        public FileManipulator fileManip { get; protected set; }


        public DataAccessObject dao { get; protected set; }



        public HashSet<int> IDCollection { get; protected set; }

        public ReportsManager()
        {
            searcher = new Searcher();
            writer = new Writer();
            fileManip = new FileManipulator();

            dao = new DataAccessObject();
            dao.Fill();

        }

        public void RegisterID(int id)
        {
            if (IDCollection.Contains(id) == false)
                IDCollection.Add(id);
        }

        public void RegisterID(List<int> idList)
        {
            foreach (int id in idList)
            {
                if (IDCollection.Contains(id) == false)
                    IDCollection.Add(id);
            }
        }
        
        public List<int> DBToDriveCheck()
        {
            List<int> idList = new List<int>();
            
            foreach (System.Data.DataRow row in dao.ds.TCDB_FilesToDelete.Rows)
            {
                int id = Convert.ToInt32(row["reportid"].ToString());

                if (IDCollection.Contains(id) == false)
                    idList.Add(id);
            }

            
            return idList;
            
        }

        public List<int> DriveToDBCheck()
        {
            List<int> idList = new List<int>();

            DataAccessObject dao = new DataAccessObject();
            FileDataSet ds = new FileDataSet();

            foreach (int id in IDCollection)
            {
                object row = dao.getCompanyInfo(id);

                if (row == null)
                    idList.Add(id);
            }

            return idList;

        }

        public void WriteDiscrpeneciesToFile(string filePath)
        {
            List<int> discrepencyList = new List<int>();

            discrepencyList = DriveToDBCheck();
            
            writer.WriteLineTo(filePath, "ID's that exist in the Harddrive but not the Database");
            foreach (int id in discrepencyList)
            {
                writer.WriteLineTo(filePath, id.ToString());
            }

            discrepencyList = DBToDriveCheck();

            writer.WriteLineTo(filePath, "ID's that exist in the Database but not the Harddrive");
            foreach (int id in discrepencyList)
            {
                writer.WriteLineTo(filePath, id.ToString());
            }
        }














        public void RegisterReport(int reportID)
        {
            IDCollection.Add(reportID);
        }

        public void UnregisterReport(int reportID)
        {
            IDCollection.Remove(reportID);
        }


    }
}
