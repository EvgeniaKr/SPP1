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
        object stop = new();
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
            lock (stop)
            {
                var TId = Thread.CurrentThread.ManagedThreadId; //get id of thread
                Tread TTread;
                //check if the thread is already in dictionary 
                if (Treads.ContainsKey(TId)) //ищет есть ли в списке есть обьект класса ThreadTracers соотв опр потоку 
                {
                    TTread = Treads[TId];
                }
                else// если нет создаёт
                {
                    TTread = new Tread(TId);
                    Treads.Add(TId, TTread);
                }

                TTread.StartTrace();
            }
        }

        public void StopTrace()
        {
            lock (stop)
            {
                var TId = Thread.CurrentThread.ManagedThreadId;
                if (Treads.ContainsKey(TId))
                {
                    Tread threadTracer = Treads[TId];
                    threadTracer.StopTrace();
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

}
