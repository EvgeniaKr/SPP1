using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Core;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;

namespace Tracer.Serialization
{
    public class Yaml : Tracer.Serialization.Abstractions.Serialization
    {
        public void Serialize(TraceResult traceResult, Stream to)
        {
            var serializer = new SerializerBuilder()
            // .WithNamingConvention(CamelCaseNamingConvention.Instance)
             .Build();
            var yaml = serializer.Serialize(traceResult);
            byte[] byteArray = Encoding.UTF8.GetBytes(yaml);
            to.Write(byteArray, 0, byteArray.Length);
        }
    }
}
