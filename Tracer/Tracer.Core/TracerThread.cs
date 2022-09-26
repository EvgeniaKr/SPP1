using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tracer.Core
{
    public class TracerThread
    {
        public int TId { get; set; }//идентификатор потока

        public double Time//время исполнения потока
        {
            get
            {
                double time = 0;
                foreach (var methodTraceResult in Methods)
                {
                    time += methodTraceResult.Time;
                }
                return time;
            }
            set
            {

            }
        }
        public List<ThreadMethods> Methods { get; }


        public TracerThread()
        {
        }

        public TracerThread(int Id)
        {
            TId = Id;
            Methods = new List<ThreadMethods>();
        }
        public void AddMethod(ThreadMethods method)
        {
            Methods.Add(method);
        }

    }
}
