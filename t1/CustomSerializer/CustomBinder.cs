using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace CustomSerializer
{
    public class CustomBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            Assembly asm = Assembly.Load(assemblyName);
            return asm.GetType(typeName);
        }
        
    }
}