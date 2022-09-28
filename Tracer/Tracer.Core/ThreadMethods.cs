using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tracer.Core
{
    [Serializable]
    public class ThreadMethods
    {
        [XmlAttribute]
        public string Class { get; set; }
        [XmlAttribute]
        public string Method { get; set; }
        [XmlAttribute]
        public double Time { get; set; }
        [XmlElement("method")]
        

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
