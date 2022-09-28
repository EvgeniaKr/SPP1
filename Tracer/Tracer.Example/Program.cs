using System.Reflection;
using Tracer.Core;
using Tracer.Serialization.Abstractions;

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


            while (thread.IsAlive)
            {

            }

            var res = tracer.GetTraceResult();

          
            XmlSerilaization(res);

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

        

        private static void XmlSerilaization(TraceResult res)
        {
            MethodInfo myMethod = null;
            object obj = Tracer.Core.TSerialization.getAddon("Tracer.Serialization.Xml", "Serialize", ref myMethod);
            using (FileStream fs = new FileStream("methods.xml", FileMode.Create))
            {
                myMethod.Invoke(obj, new object[] { res, fs });
            }
        }

    }
}