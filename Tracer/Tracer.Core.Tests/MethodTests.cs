using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tracer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Tracer.Core.Tests
{
    [TestClass()]
    public class MethodTests
    {
        private const string Class = "Class1";
        private const string Method = "Method1";
        private const string Class2 = "Class2";
        private const string Method2 = "Method2";
        private Method MMethod;
        [TestMethod()]
        public void MethodTest()
        {
            MMethod = new Method();
            MMethod.StartTrace(Class, Method);
            MMethod.StartTrace(Class2, Method2);
            MMethod.StopTrace();
            MMethod.StopTrace();
            var result = MMethod.GetTraceResult();
            Assert.AreEqual(result.Class, Class);
            Assert.AreEqual(result.Method, Method);
            result = result.TThreadMethods[0]; 
            Assert.AreEqual(result.Class, Class2);
            Assert.AreEqual(result.Method, Method2);
        }

        
    }
}