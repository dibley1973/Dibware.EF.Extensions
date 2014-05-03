using Dibware.EF.Extensions.Contracts;
using Dibware.EF.Extensions.Helpers;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Dibware.EF.Extensions
{
    /// <summary>
    /// Encapsulates extensions for System.Data.Entity.Database
    /// </summary>
    public static class DatabaseExtensions
    {
        /// <summary>
        /// Executes the specified stored procedure.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="database">The database.</param>
        /// <param name="procedure">The procedure.</param>
        /// <returns></returns>
        public static IEnumerable<TResult> ExecuteStoredProcedure<TResult>(
            this Database database,
            IStoredProcedure<TResult> procedure) where TResult : class
        {
            var sqlCommandString = CommandHelper.CreateStoredProcedureCommandString<TResult>(procedure.FullName, procedure.Parameters);
            var result = database
                .SqlQuery<TResult>(
                    sqlCommandString,
                    procedure.Parameters.ToArray())
                .ToList();
            return result;
        }
    }
}