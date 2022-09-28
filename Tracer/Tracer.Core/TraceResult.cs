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
    public class TraceResult
    {
        [XmlElement("thread")]
        [JsonPropertyName("thread")]
    
        public List<TracerThread> TTracerThread { get; }

        public TraceResult()
        {
            TTracerThread = new List<TracerThread>();
        }

        public void AddThread(TracerThread thread)
        {
            TTracerThread.Add(thread);
        }    
        
    }
}
