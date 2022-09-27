using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Core
{
    public class TracerRealize : ITracer
    {
        private TraceResult result { get; }
        private Stopwatch stopWatch;
        private Dictionary<int, Tread> Treads { get; }

        private ThreadMethods res;
        ThreadMethods InnerMethod;
        public TracerRealize()
        {
            result = new TraceResult();
            Treads = new Dictionary<int, Tread>();
        }
        public TraceResult GetTraceResult()
        {
            return result;
        }

        public void StartTrace()
        {
            var stackTrace = new StackTrace();
            var method = stackTrace.GetFrame(2).GetMethod(); //извлекается инф о методе
            var methodName = method.Name;
            var className = method.DeclaringType.FullName;
            res = new ThreadMethods(className, methodName);
        }

        public void StopTrace()
        {
            
           // var time = stopWatch.Elapsed.TotalMilliseconds;
        }
    }
    
}
