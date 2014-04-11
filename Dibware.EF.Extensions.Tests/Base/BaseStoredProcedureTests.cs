using Dibware.EF.Extensions.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Dibware.EF.Extensions.Tests.Base
{
    [TestClass]
    public class BaseStoredProcedureTests
    {
        [TestMethod]
        public void Test_InstanciateWithNameGetFullName_ResultsIn_CorrectFormatWithDefaulSchema()
        {
            // Arrange
            //const String schema = "dbo";
            const String name = "Myproc";
            var expectedResult = String.Concat(MockProcedure.DefaultSchema, @".", name);
            var procedure = new MockProcedure(name);

            // Act
            var result = procedure.FullName;

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Test_InstanciateWithSchemaAndNameGetFullName_ResultsIn_CorrectFormat()
        {
            // Arrange
            const String schema = "app";
            const String name = "Myproc";
            var expectedResult = String.Concat(schema, @".", name);
            var procedure = new MockProcedure(schema, name);

            // Act
            var result = procedure.FullName;

            // Assert
            Assert.AreEqual(expectedResult, result);
        }


        [TestMethod]
        public void Test_InstanciateWithParameterDictionary_ResultsInCorrectParameterCount()
        {
            // Arrange
            const String param1Name = "param1";
            const String param1Value = "sponge";
            const String param2Name = "params";
            const String param2Value = "bob";
            const String name = "Myproc";
            var parameterDictionary = new Dictionary<String, Object>()
            {
                { param1Name, param1Value },
                { param2Name, param2Value }
            };
            var expectedCount = parameterDictionary.Count;
            var procedure = new MockProcedure(name, parameterDictionary);

            // Act
            var parameters =procedure.Parameters;
            var actualCount = parameters.Count();

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}