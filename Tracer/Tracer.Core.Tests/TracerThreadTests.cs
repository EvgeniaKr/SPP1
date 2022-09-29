using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tracer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tracer.Core.Tests
{
    [TestClass()]
    public class TracerThreadTests
    {
        private const int TId = 1;
        private const double Time = 0;

        private ThreadMethods TThreadMethods;
        private TracerThread TTracerThread;
        [TestMethod()]
        public void TracerThreadIDTest()
        {
            TTracerThread = new TracerThread(TId);
            var result = TTracerThread.TId;
            Assert.AreEqual(TId, result);
        }

        [TestMethod()]
        public void TracerThreadTimeTest()
        {
            TTracerThread = new TracerThread(TId);
            var result = TTracerThread.Time;
            Assert.AreEqual(Time, result);
        }

        [TestMethod()]
        public void AddMethodTest()
        {
            TTracerThread = new TracerThread(TId);
            TThreadMethods = new ThreadMethods("Class1", "Method1") { Time = Time };
            TThreadMethods.AddThreadMethods(TThreadMethods);
            var result = TThreadMethods.TThreadMethods[0];
            Assert.AreEqual(TThreadMethods, result);
        }
    }
}