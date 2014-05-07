using Dibware.EF.Extensions.Contracts;
using Dibware.EF.Extensions.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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
            var sqlCommandString =
                CommandHelper.CreateStoredProcedureCommandString<TResult>(
                    procedure.FullName,
                    procedure.Parameters
                );
            var result = database
                .SqlQuery<TResult>(
                    sqlCommandString,
                    procedure.Parameters.ToArray())
                .ToList();
            return result;
        }

        /// <summary>
        /// Executes the scalar command text.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="database">The database.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        public static T ExecuteScalarCommandText<T>(
            this Database database,
            String commandText)
        {
            // Get a local reference to the connection and cache the currentstate
            DbConnection connection = ((DbConnection)database.Connection);
            var initialConnectionState = connection.State;

            // If the current connection state is closed, open it
            if (initialConnectionState == ConnectionState.Closed)
            {
                connection.Open();
            }

            // Create a variable to hold the result
            T result;

            // Create a self disposing command, set it up and execute it
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = commandText;
                command.CommandType = CommandType.Text;
                result = (T)command.ExecuteScalar();
            }

            // If the initial connection state was closed close the connection
            if (initialConnectionState == ConnectionState.Closed)
            {
                connection.Close();
            }

            // return the result
            return result;
        }


        /// <summary>
        /// Executes the scalar stored procedure.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="database">The database.</param>
        /// <param name="procedure">The procedure.</param>
        /// <returns></returns>
        public static T ExecuteScalarStoredProcedure<T>(
            this Database database,
            IStoredProcedure<T> procedure)
        {
            // Create Sql command string
            var sqlCommandString =
                CommandHelper.CreateStoredProcedureCommandString<T>(
                    procedure.FullName,
                    procedure.Parameters
                );


            // Get a local reference to the connection and cache the currentstate
            DbConnection connection = ((DbConnection)database.Connection);
            var initialConnectionState = connection.State;

            // If the current connection state is closed, open it
            if (initialConnectionState == ConnectionState.Closed)
            {
                connection.Open();
            }

            // Create a variable to hold the result
            T result;

            var parametersList = procedure.Parameters.ToList();

            // Create a self disposing command, set it up and execute it
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = sqlCommandString;
                command.CommandType = CommandType.Text;

                foreach (var parameter in parametersList)
                {
                    command.Parameters.Add(parameter);
                }

                result = (T)command.ExecuteScalar();
            }

            // If the initial connection state was closed close the connection
            if (initialConnectionState == ConnectionState.Closed)
            {
                connection.Close();
            }

            // return the result
            return result;
        }
    }
}