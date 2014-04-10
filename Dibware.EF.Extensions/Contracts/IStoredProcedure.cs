using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dibware.EF.Extensions.Contracts
{
    /// <summary>
    /// Defines the expected members of a stored procedure
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface IStoredProcedure<TResult>
    {
        /// <summary>
        /// Gets the full name including schema
        /// </summary>
        String FullName { get; }

        /// <summary>
        /// Gets the procedure name
        /// </summary>
        String Name { get; }

        /// <summary>
        /// Gets the schema of the procedure
        /// </summary>
        String Schema { get; }

        /// <summary>
        /// Gets the procedure  parameteres
        /// </summary>
        IEnumerable<SqlParameter> Parameters { get; }
    }
}
