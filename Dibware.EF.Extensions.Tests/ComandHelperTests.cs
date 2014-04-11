using Dibware.EF.Extensions.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Dibware.EF.Extensions.Tests
{
    [TestClass]
    public class ComandHelperTests
    {
        [TestMethod]
        public void Test_CreateStoredProcedureCommandString_ReturnsCorrectlyFormattedString()
        {
            // Arrange
            const String storedProcedureName = "sproc";
            const String param1Name = "param1";
            const String param1Value = "sponge";
            const String param2Name = "params";
            const String param2Value = "bob";
            var expectedResult = String.Format("{0} @{1}, @{2}", storedProcedureName, param1Name, param2Name);
            var parameterDictionary = new Dictionary<String, Object>()
            {
                { param1Name, param1Value },
                { param2Name, param2Value }
            };
            var parameters =
                ParameterHelper.BuildParametersFromDictionary(parameterDictionary);

            // Act
            var result = CommandHelper.CreateStoredProcedureCommandString<Boolean>(storedProcedureName, parameters);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}