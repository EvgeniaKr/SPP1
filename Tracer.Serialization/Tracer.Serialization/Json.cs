using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tracer.Core;

namespace Tracer.Serialization
{
    public class Json : Tracer.Serialization.Abstractions.Serialization
    {

        public void Serialize(TraceResult traceResult, Stream to)
        {
            JsonSerializer.Serialize<TraceResult>(to, traceResult);
        }
    }
}
