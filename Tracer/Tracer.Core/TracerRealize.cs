using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Core
{
    public class TracerRealize : ITracer
    {
        private TraceResult result { get; }
        

        public TracerRealize()
        {
            
        }
        public TraceResult GetTraceResult()
        {
            
            return result;
        }

        public void StartTrace()
        {
            
        }

        public void StopTrace()
        {
            
        }
    }
    
}
