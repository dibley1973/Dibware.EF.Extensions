using Dibware.EF.Extensions.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Dibware.EF.Extensions.Tests
{
    [TestClass]
    public class DatabaseExtensionsTests
    {
        [TestMethod]
        public void Test_ExecuteScalarCommandText_Using_ReturnsIntegerValue()
        {
            // Arrange
            Database database;
            var connectionString = Properties.Settings.Default.MasterConnection;
            var commandText = @"SELECT TOP 1 [ORDINAL_POSITION] FROM [master].[INFORMATION_SCHEMA].[COLUMNS]";
            var expectedType = typeof(int);

            // Act
            DbConnection connection = new SqlConnection(connectionString);
            var dbContext = new DbContext(connectionString);
            database = dbContext.Database;
            var result = database.ExecuteScalarCommandText<int>(commandText);

            // Assert
            Assert.IsInstanceOfType(result, expectedType);
        }

        [TestMethod]
        public void Test_ExecuteScalarStoredProcedureWithNoParameters_Using_ReturnsIntegerValue()
        {
            // Arrange
            Database database;
            var connectionString = Properties.Settings.Default.TempConnection;
            var createProcedureCommandText = ScalarTestStoredProcedure.CreateProcedureText;
            var dropProcedureCommandText = ScalarTestStoredProcedure.DropProcedureText;
            var expectedType = typeof(int);
            var storedProcedure = new ScalarTestStoredProcedure();

            // Act
            DbConnection connection = new SqlConnection(connectionString);
            var dbContext = new DbContext(connectionString);
            database = dbContext.Database;

            // Create, Execute and drop the procedure
            database.ExecuteSqlCommand(createProcedureCommandText);
            var result = database.ExecuteScalarStoredProcedure(storedProcedure);
            database.ExecuteSqlCommand(dropProcedureCommandText);

            // Assert
            Assert.IsInstanceOfType(result, expectedType);
        }

        [TestMethod]
        public void Test_ExecuteScalarStoredProcedureWithParameters_Using_ReturnsIntegerValue()
        {
            // Arrange
            Database database;
            var connectionString = Properties.Settings.Default.TempConnection;
            var createProcedureCommandText = ScalarTestStoredProcedureWithParam.CreateProcedureText;
            var dropProcedureCommandText = ScalarTestStoredProcedureWithParam.DropProcedureText;
            var expectedType = typeof(int);
            var param1 = 10;
            var storedProcedure = new ScalarTestStoredProcedureWithParam(param1);
            Int32 result;

            // Act
            DbConnection connection = new SqlConnection(connectionString);
            var dbContext = new DbContext(connectionString);
            database = dbContext.Database;
            
            // Create, Execute and drop the procedure
            try
            {
                database.ExecuteSqlCommand(createProcedureCommandText);
                result = database.ExecuteScalarStoredProcedure(storedProcedure);
            }
            finally
            {
                database.ExecuteSqlCommand(dropProcedureCommandText);
            }
            // Assert
            Assert.IsInstanceOfType(result, expectedType);
        }
    }
}