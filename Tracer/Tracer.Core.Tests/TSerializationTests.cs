using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tracer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Serialization;

namespace Tracer.Core.Tests
{
    [TestClass()]
    public class TSerializationTests
    {
        private Json json;
        private const string Serialized = "{\"thread\":[]}";
        private Xml xml;
        private const string Serializedx = "???<?xml version=\"1.0\" encoding=\"utf-8\"?><TraceResult xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" />";
        private Yaml yaml;
        private const string Serializedy = "thread: []\r\n";
        [TestMethod()]
        public void JsonTest()
        {
            json = new Json();
            var TTraceResult = new TraceResult();
            using (MemoryStream ms = new MemoryStream())
            {
                json.Serialize(TTraceResult, ms);
                Assert.AreEqual(Serialized, Encoding.ASCII.GetString(ms.ToArray()));
            }
        }
        public void XmlTest()
        {
            xml = new Xml();
            var TTraceResult = new TraceResult();
            using (MemoryStream ms = new MemoryStream())
            {
                xml.Serialize(TTraceResult, ms);
                Assert.AreEqual(Serializedx, Encoding.ASCII.GetString(ms.ToArray()));
            }
        }
        public void YamlTest()
        {
            yaml = new Yaml();
            var TTraceResult = new TraceResult();
            using (MemoryStream ms = new MemoryStream())
            {
                yaml.Serialize(TTraceResult, ms);
                Assert.AreEqual(Serializedy, Encoding.ASCII.GetString(ms.ToArray()));
            }
        }
    }
}