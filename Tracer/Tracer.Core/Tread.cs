using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Core
{
    public class Tread
    {
        public TracerThread TTracerThread { get; }

        private Method cur;

        public Tread(int id)
        {
            TTracerThread = new TracerThread(id);
            cur = null;
        }
        public void StartTrace()
        {
            var SStackTrace = new StackTrace();
            var m = SStackTrace.GetFrame(2).GetMethod(); //извлекается инф о методе
            var Method = m.Name;
            var Class = m.DeclaringType.FullName;

            //внутри потока должен имется всего один текущий метод
            if (cur == null)
            {
                cur = new Method();
            }

            cur.StartTrace(Class, Method);
        }

        public void StopTrace()
        {
            //внутри потока должен быть метод
            if (cur != null)
            {
                cur.StopTrace();
                if (cur.IsActive() == false)
                {
                    var CurGetTraceResult = cur.GetTraceResult();
                    TTracerThread.AddMethod(CurGetTraceResult);
                    cur = null;
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }


    }
}

