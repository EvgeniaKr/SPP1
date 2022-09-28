using Tracer.Core;

namespace Tracer.Serialization.Abstractions
{
    public interface Serialization
    {
        void Serialize(TraceResult traceResult, Stream to);
    }
}