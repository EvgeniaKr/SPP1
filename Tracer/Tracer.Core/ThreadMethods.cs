using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Core
{
    public class ThreadMethods
    {
         public string Class { get; set; }
        
        public string Method { get; set; }
        
        public double Time { get; set; }

        
        public List<ThreadMethods> TThreadMethods { get; } //содержит список вложенных в него методов

        public ThreadMethods(string className, string methodName)
        {
            Time = 0;
            Class = className;
            Method = methodName;
            TThreadMethods = new List<ThreadMethods>();
        }

        public ThreadMethods()
        {
        }


        public void AddThreadMethods(ThreadMethods method)
        {
            TThreadMethods.Add(method);
        }
    }
}
