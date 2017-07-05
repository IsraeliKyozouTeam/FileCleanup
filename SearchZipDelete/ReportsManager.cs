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


        public List<int> DBCheckToDrive()
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

        public List<int> DriveCheckToDB()
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

        public Write














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
