using System.Diagnostics;
using System.Threading;
using Tracer.Core;
using Tracer.Example;
namespace Tracer.Core.Tests
{
    [TestClass]
    public class TestTraserRealize
    {
        private TracerRealize TTracerRealize;

        [TestMethod]
        public void TestThreadsStartStop()
        {
            TTracerRealize = new TracerRealize();

            Thread ThreadMain = new Thread(Print);
            ThreadMain.Start();
            Thread ThreadDop = new Thread(Print);
            ThreadDop.Start();
           
            while (ThreadDop.IsAlive || ThreadMain.IsAlive)
            {

            }
            var res = TTracerRealize.GetTraceResult();
            Assert.AreEqual(2, res.TTracerThread.Count);
        }
        void Print()
        {
            TTracerRealize.StartTrace();
            Thread.Sleep(200);
            TTracerRealize.StopTrace();
        }
    }
}