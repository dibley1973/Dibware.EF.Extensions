using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dibware.EF.Extensions.Helpers
{
    /// <summary>
    /// Contains helper methods for parameters
    /// </summary>
    public static class ParameterHelper
    {
        /// <summary>
        /// Builds the parameters from dictionary.
        /// </summary>
        /// <param name="paramters">The paramters.</param>
        /// <returns></returns>
        public static IEnumerable<SqlParameter> BuildParametersFromDictionary(
            IDictionary<String, Object> paramters)
        {
            var result = new List<SqlParameter>();
            foreach (var parameter in paramters)
            {
                var sqlParameter = ConvertKeyValuePairToSqlParameter(parameter);
                result.Add(sqlParameter);
            }
            return (IEnumerable<SqlParameter>)result;
        }

        /// <summary>
        /// Converts the key value pair to SQL parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        public static SqlParameter ConvertKeyValuePairToSqlParameter(
            KeyValuePair<String, Object> parameter)
        {
            return new SqlParameter(String.Format("@{0}", parameter.Key), parameter.Value);
        }
    }
}
