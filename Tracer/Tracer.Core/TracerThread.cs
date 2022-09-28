using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tracer.Core
{
    [Serializable]
    public class TracerThread
    {
        [XmlAttribute]
        [JsonPropertyName("Id")]
       
        public int TId { get; set; }//идентификатор потока
        [XmlAttribute]
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
        [XmlElement("method")]
        public List<ThreadMethods>? Methods { get; }


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
