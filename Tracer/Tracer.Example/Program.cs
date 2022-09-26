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


            Console.WriteLine();
        }

        private static void StartPr()
        {
            tracer.StartTrace();
            Thread.Sleep(200);
            tracer.StopTrace();
        }
    }
}