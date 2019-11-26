using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Bookstore;
using Bookstore.Entities;

namespace CustomSerializer
{
    public partial class Serializer : Formatter, ISerializer
    {
        protected override void WriteValueType(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }

        public override SerializationBinder Binder { get; set; }
        public override StreamingContext Context { get; set; }
        public override ISurrogateSelector SurrogateSelector { get; set; }

        private string SerializedData = "";
        private List<string> StreamWriteData = new List<string>();
        private List<string> StreamReadData = new List<string>();
        private Dictionary<string, object> _dict = new Dictionary<string, object>();

        public override object Deserialize(Stream serializationStream)
        {
            ReadStream(serializationStream);
            foreach (string row in StreamReadData)
            {
                string[] split = row.Split(';');
                Type objType = Binder.BindToType(split[0], split[1]);
                SerializationInfo info = new SerializationInfo(objType, new FormatterConverter());
                
            }

            return null;
        }

        public override void Serialize(Stream serializationStream, object graph)
        {
            if (graph is ISerializable data)
            {
                SerializationInfo serInfo = new SerializationInfo(graph.GetType(), new FormatterConverter());
                Binder.BindToName(graph.GetType(), out string assemblyName, out string typeName);
                SerializedData += assemblyName + ";" + typeName + ";" + this.m_idGenerator.GetId(graph, out bool firstTime);
                data.GetObjectData(serInfo, Context);

                foreach (SerializationEntry item in serInfo)
                {
                    WriteMember(item.Name, item.Value);
                }

                while (m_objectQueue.Count != 0)
                {
                    this.Serialize(null, this.m_objectQueue.Dequeue());
                }

                WriteStream(serializationStream);
            }
            else
            {
                throw new ArgumentException("Graph is not an ISerializable");
            }
            
        }

        private void WriteStream(Stream stream)
        {
            if (stream != null)
            {
                StreamWriter sw = new StreamWriter(stream);
                foreach (string s in StreamWriteData)
                {
                    sw.Write(s);
                }
                sw.Close();
            }
        }

        private void ReadStream(Stream stream)
        {
            if (stream != null)
            {
                StreamReader sr = new StreamReader(stream);
                String s;
                while ((s = sr.ReadLine()) != null)
                {
                    StreamReadData.Add(s);
                }
            }
            ConstructReference();
        }

        private void ConstructReference()
        {
            foreach (string s in StreamReadData)
            {
                String[] split = s.Split(';');
                _dict.Add(split[2], FormatterServices.GetSafeUninitializedObject(Binder.BindToType(split[0], split[1])));
            }
        }

        private void SaveToStream()
        {
            StreamWriteData.Add(SerializedData + "\n");
            SerializedData = "";
        }
        
        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {
            if (memberType.Equals(typeof(String)))
            {
                SerializedData += ";" + obj.GetType() + "=" + name + "=\"" + (String) obj + "\"";
            }
            else
            {
                WriteObject(obj, name, memberType);
            }
        }

        protected void WriteObject(object obj, string name, Type type)
        {
            if (obj != null)
            {
                SerializedData += ";" + obj.GetType() + "=" + name + "=" +
                                  this.m_idGenerator.GetId(obj, out bool firstTime).ToString();
                if (firstTime)
                {
                    this.m_objectQueue.Enqueue(obj);
                }
            }
            else
            {
                SerializedData += ";" + "null" + "=" + name + "=-1";
            }
        }

        protected override void WriteDateTime(DateTime val, string name)
        {
            SerializedData += ";" + val.GetType() + "=" + name + "=" + val.ToUniversalTime().ToString("f");
        }
        
        protected override void WriteArray(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }

        protected override void WriteBoolean(bool val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteByte(byte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteChar(char val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDecimal(decimal val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDouble(double val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt16(short val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt32(int val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt64(long val, string name)
        {
            throw new NotImplementedException();
        }
        
        protected override void WriteSByte(sbyte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteSingle(float val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteTimeSpan(TimeSpan val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt16(ushort val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt32(uint val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt64(ulong val, string name)
        {
            throw new NotImplementedException();
        }
    }
}