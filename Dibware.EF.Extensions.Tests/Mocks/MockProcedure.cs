using Dibware.EF.Extensions.Base;
using System;
using System.Collections.Generic;

namespace Dibware.EF.Extensions.Tests.Mocks
{
    internal class MockProcedure : BaseStoredProcedure<Boolean>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MockProcedure"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public MockProcedure(String name)
            : base(name) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MockProcedure"/> class.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="name">The name.</param>
        public MockProcedure(String schema, String name)
            : base(schema, name) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MockProcedure"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="parameters">The parameters.</param>
        public MockProcedure(String name, IDictionary<String, Object> parameters)
            : base(name, parameters) { }
    }
}