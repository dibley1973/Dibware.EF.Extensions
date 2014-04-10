using Dibware.EF.Extensions.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Dibware.System.Extensions.System.Collections.Generic;

namespace Dibware.EF.Extensions
{
    public static class DatabaseExtensions
    {
        public static IEnumerable<TResult> ExecuteStoredProcedure<TResult>(
            this Database database, 
            IStoredProcedure<TResult> procedure)
        {
            var sqlCommand = CreateSPCommand<TResult>(procedure.FullName, procedure.Parameters);
            return database.SqlQuery<TResult>(sqlCommand, procedure.Parameters.Cast<object>().ToArray());
        }

        private static string CreateSPCommand<TResult>(String storedProcedureName, IEnumerable<SqlParameter> parameters)
        {
            var queryString = storedProcedureName;
            parameters.ForEach(x => queryString = String.Format("{0} {1},", queryString, x.ParameterName));
            return queryString.TrimEnd(',');
        }
    }
}
