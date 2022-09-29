using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Core
{
    public class Method
    {
        private Stopwatch stop;
        private ThreadMethods result;
        Method MMethod;

        //   private bool isNestedMethod = false;

        bool isActive; //contains value, that indicates whether an outer method is the previous method is active
       
        public Method()
        {
            stop = new Stopwatch();
            MMethod = null;
            bool isActive = false;
        }
        public ThreadMethods GetTraceResult()
        {
            StackTrace SStackTrace = new StackTrace();
            return result;
        }

        public void StartTrace(string Class, string Name)
        {
            if (isActive == false) //является ли метод вложенным: нет - true, да - false
            {
                isActive = true; //make a method an outer method for someone
                stop.Start();
                result = new ThreadMethods(Class, Name);
            }
            else
            {
                if (MMethod == null)
                {
                    MMethod = new Method();
                }
                MMethod.StartTrace(Class, Name);
            }
        }

        public void StopTrace()
        {
            if (isActive == true)
            {
                if (MMethod != null) // если вложенный метод есть
                {
                    MMethod.StopTrace();
                    if (MMethod.IsActive() == false)
                    {
                        var MethodGetTraceResult = MMethod.GetTraceResult();
                        MMethod = null;
                        result.AddThreadMethods(MethodGetTraceResult);
                    }
                }
                else
                {
                    stop.Stop();
                    result.Time = stop.Elapsed.TotalMilliseconds;
                    isActive = false;
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public bool IsActive()
        {
            return isActive;
        }        
    }
}
