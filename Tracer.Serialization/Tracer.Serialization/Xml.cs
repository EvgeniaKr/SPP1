using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Tracer.Core;

namespace Tracer.Serialization
{
    public class Xml : Tracer.Serialization.Abstractions.Serialization
    {
        public void Serialize(TraceResult traceResult, Stream to)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TraceResult));
            xmlSerializer.Serialize(to, traceResult);
        }
    }
}
