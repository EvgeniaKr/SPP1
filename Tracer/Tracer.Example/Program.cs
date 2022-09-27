using System.Reflection;
using Tracer.Core;

namespace Tracer.Example
{
    internal class Program
    {
        private static ITracer tracer = new TracerRealize();
        static void Main(string[] args)
        {

            StartPr();

            ThreadMethods tr = new ThreadMethods();
            Console.WriteLine(tr.Class);
            Console.WriteLine(tr.Method);
            Console.WriteLine(tr.Time);
        }

        private static void StartPr()
        {
            tracer.StartTrace();
            Thread.Sleep(200);
            tracer.StopTrace();
        }
    }
}