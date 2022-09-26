using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tracer.Core
{
    public class TraceResult
    {
        public List<Thread> Threads { get; }

        public TraceResult()
        {
            Threads = new List<Thread>();
        }

        public void AddThread(Thread thread)
        {
            Threads.Add(thread);
        }        
    }
}
