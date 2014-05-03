using Dibware.Extensions.System.Collections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Dibware.EF.Extensions.Helpers
{
    public static class CommandHelper
    {
        public static String CreateStoredProcedureCommandString<TResult>(
            String storedProcedureName,
            IEnumerable<SqlParameter> parameters)
        {
            var queryString = String.Concat("EXEC ", storedProcedureName);
            parameters.ForEach(x => queryString = String.Format("{0} {1},", queryString, x.ParameterName));
            return queryString.TrimEnd(',');
        }
    }
}