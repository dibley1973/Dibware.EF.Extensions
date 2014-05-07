using Dibware.EF.Extensions.Base;
using System;
using System.Collections.Generic;

namespace Dibware.EF.Extensions.Tests.Mocks
{
    internal class ScalarTestStoredProcedure : BaseStoredProcedure<Int32>
    {
        public const String ProcedureName = @"ScalarTest";
        public const String ProcedureSchema = @"dbo";
        public const String CreateProcedureText = @"CREATE PROCEDURE "
            + ProcedureSchema + "." + ProcedureName
            + " AS BEGIN SELECT 10; END;";
        public const String DropProcedureText = @"DROP PROCEDURE "
            + ProcedureSchema + "." + ProcedureName + ";";

        /// <summary>
        /// Initializes a new instance of the <see cref="ScalarTestStoredProcedure" /> class.
        /// </summary>
        public ScalarTestStoredProcedure()
            : base(ProcedureSchema, ProcedureName, new Dictionary<String, Object>() { })
        { }
    }
}
