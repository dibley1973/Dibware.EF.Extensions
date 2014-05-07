using Dibware.EF.Extensions.Base;
using System;
using System.Collections.Generic;

namespace Dibware.EF.Extensions.Tests.Mocks
{
    internal class ScalarTestStoredProcedureWithParam : BaseStoredProcedure<Int32>
    {
        public const String ProcedureName = @"ScalarTestWithParam";
        public const String ProcedureSchema = @"dbo";
        public const String CreateProcedureText = @"CREATE PROCEDURE "
            + ProcedureSchema + "." + ProcedureName
            + "  (@param1 int) AS BEGIN SELECT @param1; END;";
        public const String DropProcedureText = @"DROP PROCEDURE "
            + ProcedureSchema + "." + ProcedureName + ";";

        /// <summary>
        /// Initializes a new instance of the <see cref="ScalarTestStoredProcedureWithParam" /> class.
        /// </summary>
        public ScalarTestStoredProcedureWithParam(Int32 param1)
            : base(ProcedureSchema, ProcedureName, new Dictionary<String, Object>() 
            {
                { "param1", param1 }
            })
        { }
    }
}
