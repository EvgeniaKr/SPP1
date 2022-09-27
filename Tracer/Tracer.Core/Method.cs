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
        private Stopwatch stopWatch;
        private ThreadMethods result;
        Method InnerMethod;

        //   private bool isNestedMethod = false;

        bool isActive; //contains value, that indicates whether an outer method is the previous method is active
        public Stack<Method>? NestedMethod { get; }
        public Method()
        {
            stopWatch = new Stopwatch();
            InnerMethod = null;
            bool isActive = false;
        }
        public ThreadMethods GetTraceResult()
        {
            StackTrace stackTrace = new StackTrace();
            return result;
        }

        public void StartTrace(string className, string methodName)
        {
            if (isActive == false) //является ли метод вложенным: нет - true, да - false
            {
                isActive = true; //make a method an outer method for someone
                stopWatch.Start();
                result = new ThreadMethods(className, methodName);
            }
            else
            {
                if (InnerMethod == null)
                {
                    InnerMethod = new Method();
                }
                InnerMethod.StartTrace(className, methodName);
            }
        }

        public void StopTrace()
        {
            if (isActive == true)
            {
                if (InnerMethod != null) // если вложенный метод есть
                {
                    InnerMethod.StopTrace();
                    if (InnerMethod.IsActive() == false)
                    {
                        var innerMethodTraceResult = InnerMethod.GetTraceResult();
                        InnerMethod = null;
                        result.AddThreadMethods(innerMethodTraceResult);
                    }
                }
                else
                {
                    stopWatch.Stop();
                    result.Time = getTime();
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

        private double getTime()
        {
            var time = stopWatch.Elapsed.TotalMilliseconds;
            return time;
        }
    }
}
