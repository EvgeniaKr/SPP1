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
    public class ThreadMethodsTests
    {
        private ThreadMethods TThreadMethods;

        
        [TestMethod()]
        public void ThreadMethodsTest()
        { 
            const string Class = "Class1";
            const string Method = "Method1";
            const double Time = 0;
            TThreadMethods = new ThreadMethods(Class, Method);
            var result = TThreadMethods.Class;
            Assert.AreEqual(Class, result);
            result = TThreadMethods.Method;
            Assert.AreEqual(Method, result);
            double resut = TThreadMethods.Time;
            Assert.AreEqual(Time, resut);
        }

      
    }
}