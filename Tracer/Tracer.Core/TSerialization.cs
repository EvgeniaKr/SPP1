using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Core
{
    public static class TSerialization
    {
        static string path = "..\\..\\..\\..\\..\\Tracer.Serialization\\Tracer.Serialization\\bin\\Debug\\net6.0\\Tracer.Serialization.dll";
        public static object getAddon(string Class, string Method, ref MethodInfo Inf)
        {
            // application domain.
            Assembly AssemblyLoadFrom = Assembly.LoadFrom(path);

            var types = AssemblyLoadFrom.GetTypes();

            // Get the type to use.
            Type TType = AssemblyLoadFrom.GetType(Class);
            // Get the method to call.
            Inf = TType.GetMethod(Method);

            // Create an instance.
            object result = Activator.CreateInstance(TType);
            // Execute the method.

            return result;
        }
    }
}
