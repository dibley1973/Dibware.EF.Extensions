using Dibware.EF.Extensions.Contracts;
using Dibware.EF.Extensions.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
        public IEnumerable<SqlParameter> Parameters { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseStoredProcedure{TResult}"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public BaseStoredProcedure(String name)
            : this(DefaultSchema, name) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseStoredProcedure{TResult}"/> class.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="name">The name.</param>
        public BaseStoredProcedure(String schema, String name)
            : this(schema, name, new Dictionary<String, Object>()) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseStoredProcedure{TResult}"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="parameters">The parameters.</param>
        public BaseStoredProcedure(String name, IDictionary<String, Object> parameters)
            : this(DefaultSchema, name, parameters) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseStoredProcedure{TResult}"/> class.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="name">The name.</param>
        /// <param name="parameters">The parameters.</param>
        public BaseStoredProcedure(String schema, String name, IDictionary<String, Object> parameters)
        {
            Name = name;
            Schema = schema;
            Parameters = ParameterHelper.BuildParametersFromDictionary(parameters);

        }

        #endregion
    }
}
