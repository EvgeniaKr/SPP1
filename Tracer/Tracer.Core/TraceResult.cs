using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Core
{
    public class TraceResult
    {
        public List<TracerThread> TTracerThread { get; }

        public TraceResult()
        {
            TTracerThread = new List<TracerThread>();
        }

        public void AddThread(TracerThread thread)
        {
            TTracerThread.Add(thread);
        }        
    }
}
