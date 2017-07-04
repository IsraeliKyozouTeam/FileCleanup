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

        public DataAccessObject()
        {
            adapter = new FileDataSetTableAdapters.QueriesTableAdapter();
        }

        public object getCompanyInfo(int id)
        {
            return adapter.GetFilesRowsPerCompanyId(id);             
        }
    }
}
