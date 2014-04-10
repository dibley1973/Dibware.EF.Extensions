using Dibware.EF.Extensions.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dibware.EF.Extensions.Base
{
    public abstract class BaseStoredProcedure<TResult> : IStoredProcedure<TResult>
    {
        #region Declarations

        public const String DefaultSchema = @"dbo";

        #endregion

        #region Propeties

        /// <summary>
        /// Gets the full name including schema
        /// </summary>
        public string FullName
        {
            get { return String.Concat(Schema, @".", Name); }
        }

        /// <summary>
        /// Gets the Name
        /// </summary>
        public String Name { get; private set; }

        /// <summary>
        /// Gets the schema
        /// </summary>
        public String Schema { get; private set; }

        /// <summary>
        /// Gets the parameters
        /// </summary>
        public IEnumerable<SqlParameter> Parameters { get; private set;  }

        #endregion

        #region Constructor

        
        public BaseStoredProcedure(String name, IDictionary<String, Object> parameters)
            : this(DefaultSchema, name, parameters) {}

        public BaseStoredProcedure(String schema, String name, IDictionary<String, Object> parameters)
        {
            this.Name = name;
            this.Schema = schema;
            this.BuildParameters(parameters);

        }

        #endregion

        #region Methods

        private void BuildParameters(IDictionary<String, Object> paramters)
        {
            foreach (var parameter in paramters)
            {
                var sqlParameter = ConvertParameterToSqlParameter(parameter);
            }
        }

        private object ConvertParameterToSqlParameter(KeyValuePair<String, Object> parameter)
        {
            return new SqlParameter(String.Format("@{0}", parameter.Key), parameter.Value);
        }

        #endregion
    }
}
