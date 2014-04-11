using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dibware.Extensions.System.Collections;

namespace Dibware.EF.Extensions.Helpers
{
    public static class CommandHelper
    {
        public static String CreateStoredProcedureCommandString<TResult>(
            String storedProcedureName, 
            IEnumerable<SqlParameter> parameters)
        {
            var queryString = storedProcedureName;
            parameters.ForEach(x => queryString = String.Format("{0} {1},", queryString, x.ParameterName));
            return queryString.TrimEnd(',');
        }
    }
}