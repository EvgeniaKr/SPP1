using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tracer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Core.Tests
{
    [TestClass()]
    public class TreadTests
    {
        Tread TTread;

        [TestMethod()]
        public void TreadTest()
        {
            TTread = new Tread(1);
            TTread.StartTrace();
            TTread.StopTrace();
            var result = TTread.TTracerThread;
            Assert.IsNotNull(result.Methods);
        }
    }
}