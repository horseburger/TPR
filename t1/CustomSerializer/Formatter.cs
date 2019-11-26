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

        private string _serializedData = "";
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
                SerializationInfo info = new SerializationInfo(objType ?? throw new NullReferenceException("objType is null"), new FormatterConverter());
                GetSerializationInfo(info, split);
                Type[] constructorTypes = {info.GetType(), Context.GetType()};
                object[] constructorParams = {info, Context};
                _dict[split[2]].GetType().GetConstructor(constructorTypes).Invoke(_dict[split[2]], constructorParams);
            }

            return _dict["1"];
        }

        public override void Serialize(Stream serializationStream, object graph)
        {
            if (graph is ISerializable data)
            {
                SerializationInfo serInfo = new SerializationInfo(graph.GetType(), new FormatterConverter());
                Binder.BindToName(graph.GetType(), out string assemblyName, out string typeName);
                _serializedData += assemblyName + ";" + typeName + ";" + this.m_idGenerator.GetId(graph, out bool firstTime);
                data.GetObjectData(serInfo, Context);

                foreach (SerializationEntry item in serInfo)
                {
                    WriteMember(item.Name, item.Value);
                }

                SaveToStream();
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

        private void GetSerializationInfo(SerializationInfo info, string[] split)
        {
            for (int i = 3; i < split.Length; i++)
            {
                string[] data = split[i].Split('=');
                Type type = Binder.BindToType(split[0], data[0]);
                if (type == null)
                {
                    if (!data[0].Equals("null"))
                    {
                        SaveToSerializationInfo(info, Type.GetType(data[0]), data[1], data[2]);
                    }
                    else
                    {
                        info.AddValue(data[1], null);
                    }
                }
                else
                {
                    if (!data[2].Equals("-1"))
                    {
                        info.AddValue(data[1], _dict[data[2]], type);
                    }
                }
            }
        }

        private void SaveToSerializationInfo(SerializationInfo info, Type type, string name, string val)
        {
            switch (type.ToString())
            {
                case "System.String":
                    info.AddValue(name, val);
                    break;
                case "System.Single":
                    info.AddValue(name, Single.Parse(val));
                    break;
                case "System.DateTime":
                    info.AddValue(name, DateTime.Parse(val, null, System.Globalization.DateTimeStyles.AssumeLocal));
                    break;
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
            StreamWriteData.Add(_serializedData + "\n");
            _serializedData = "";
        }
        
        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {
            if (memberType.Equals(typeof(String)))
            {
                _serializedData += ";" + obj.GetType() + "=" + name + "=\"" + (String) obj + "\"";
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
                _serializedData += ";" + obj.GetType() + "=" + name + "=" +
                                  this.m_idGenerator.GetId(obj, out bool firstTime).ToString();
                if (firstTime)
                {
                    this.m_objectQueue.Enqueue(obj);
                }
            }
            else
            {
                _serializedData += ";" + "null" + "=" + name + "=-1";
            }
        }

        protected override void WriteDateTime(DateTime val, string name)
        {
            _serializedData += ";" + val.GetType() + "=" + name + "=" + val.ToUniversalTime().ToString("O");
        }
        
        protected override void WriteSingle(float val, string name)
        {
            _serializedData += ";" + val.GetType() + "=" + name + "=" +
                              val.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
        }

    }
}