using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchZipDelete
{
    class DataAccessObject
    {
        FileDataSetTableAdapters.QueriesTableAdapter adapter;
        public FileDataSet ds { get; protected set; }

        public DataAccessObject()
        {
            adapter = new FileDataSetTableAdapters.QueriesTableAdapter();
            ds = new FileDataSet();
        }

        public object getCompanyInfo(int id)
        {
            return adapter.GetFilesRowsPerCompanyId(id);             
        }

        public void Fill()
        {
            FileDataSetTableAdapters.TCDB_FilesToDeleteTableAdapter ta = new FileDataSetTableAdapters.TCDB_FilesToDeleteTableAdapter();
            ta.Fill(ds.TCDB_FilesToDelete);
        }

        public FileDataSet.TCDB_FilesToDeleteDataTable GetData()
        {
            Fill();
            return ds.TCDB_FilesToDelete;
        }

        public object getTableData()
        {
            return adapter.GetData();
        }
    }
}
