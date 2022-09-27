using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tracer.Core
{
    public class TracerRealize : ITracer
    {
        private TraceResult result { get; }
        private Stopwatch stopWatch;
        private Dictionary<int, Tread> Treads { get; }

        public TracerRealize()
        {
            result = new TraceResult();
            Treads = new Dictionary<int, Tread>();
        }
        public TraceResult GetTraceResult()
        {
            foreach (var thread in Treads)
            {
                var threadTracer = thread.Value;
                var threadTraceResult = threadTracer.TTracerThread;
                result.AddThread(threadTraceResult);
            }
            return result;
        }

        public void StartTrace()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId; //get id of thread
            Tread threadTracer;
            //check if the thread is already in dictionary 
            if (Treads.ContainsKey(threadId)) //ищет есть ли в списке есть обьект класса ThreadTracers соотв опр потоку 
            {
                threadTracer = Treads[threadId];
            }
            else// если нет создаёт
            {
                threadTracer = new Tread(threadId);
                Treads.Add(threadId, threadTracer);
            }

            threadTracer.StartTrace();
        }

        public void StopTrace()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            if (Treads.ContainsKey(threadId))
            {
                Tread threadTracer = Treads[threadId];
                threadTracer.StopTrace();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
    
}
