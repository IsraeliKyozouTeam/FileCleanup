using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchZipDelete
{
    public class ExceptionLogger
    {

        HashSet<UnauthorizedAccessException> UnauthorizedAccessLog;
        HashSet<System.IO.DirectoryNotFoundException> DirectoryNotFoundLog;
        HashSet<Exception> GeneralExceptionLog;

        public ExceptionLogger() {
           UnauthorizedAccessLog = new HashSet<UnauthorizedAccessException>();
           DirectoryNotFoundLog = new HashSet<System.IO.DirectoryNotFoundException>();
            GeneralExceptionLog = new HashSet<Exception>();
        }
        public void addUnauthorizedException(UnauthorizedAccessException e) {
            UnauthorizedAccessLog.Add(e);
        }
        public void addDirectoryException(System.IO.DirectoryNotFoundException e)
        {
            DirectoryNotFoundLog.Add(e);
        }
        public void addGeneralException(Exception e) {
            GeneralExceptionLog.Add(e);
        }

    }
}
