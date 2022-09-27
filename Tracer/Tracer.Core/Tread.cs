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
        public TracerThread ThreadTraceResult { get; }
        private Method cur;

        public Tread(int id)
        {
            ThreadTraceResult = new TracerThread(id);
            cur = null;
        }
        public void StartTrace()
        {
            var stackTrace = new StackTrace();
            var method = stackTrace.GetFrame(2).GetMethod(); //извлекается инф о методе
            var methodName = method.Name;
            var className = method.DeclaringType.FullName;

            //внутри потока должен имется всего один текущий метод
            if (cur == null)
            {
                cur = new Method();
            }

            cur.StartTrace(className, methodName);
        }

        public void StopTrace()
        {
            if (cur != null)
            {
                cur.StopTrace();
                if (cur.IsActive() == false)
                {
                    var methodTraceResult = cur.GetTraceResult();
                    ThreadTraceResult.AddMethod(methodTraceResult);
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

