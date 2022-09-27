using System.Reflection;
using Tracer.Core;

namespace Tracer.Example
{
    internal class Program
    {
        private static ITracer tracer = new TracerRealize();
        static void Main(string[] args)
        {
            TraceResult traceResult = new TraceResult();

            Thread thread = new Thread(new ThreadStart(StartPr));
            thread.Start();

            Checkclassfirst.Checkmethodfirst(ref tracer);
            Checkclasssecond.Checkmethodsecond(ref tracer);

            

             var res = tracer.GetTraceResult();
            Console.WriteLine();

        }

        private static void StartPr()
        {
            tracer.StartTrace();
            Thread.Sleep(200);
            tracer.StopTrace();
        }
        public static class Checkclassfirst
        {
            public static void Checkmethodfirst(ref ITracer tracer)
            {
                tracer.StartTrace();
                Thread.Sleep(200);
                tracer.StopTrace();
            }
        }
        public static class Checkclasssecond
        {
            public static void Checkmethodsecond(ref ITracer tracer)
            {
                tracer.StartTrace();
                Checkclassfirst.Checkmethodfirst(ref tracer);
                Thread.Sleep(200);
                tracer.StopTrace();
            }
        }
    }
}