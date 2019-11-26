using System;
using System.Runtime.Serialization;

namespace CustomSerializer.UnitTest
{
    public class ClassB : ISerializable
    {
        public DateTime Date { get; set; }
        public float Float { get; set; }
        public string String { get; set; }
        public ClassC ClassCProp { get; set; }

        public ClassB(DateTime date, float f, string s, ClassC classCProp)
        {
            Date = date;
            Float = f;
            String = s;
            ClassCProp = classCProp;
        }

        public ClassB(SerializationInfo info, StreamingContext context)
        {
            Date = info.GetDateTime("DateProp");
            Float = info.GetSingle("FloatProp");
            String = info.GetString("StringProp");
            ClassCProp = (ClassC) info.GetValue("ClassCProp", typeof(ClassC));
        }

        public override bool Equals(object obj)
        {
            return obj is ClassB b &&
                   Date.Equals(b.Date) &&
                   Float.Equals(b.Float) &&
                   String.Equals(b.String) &&
                   ClassCProp == b.ClassCProp;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DateProp", Date);
            info.AddValue("FloatProp", Float);
            info.AddValue("StringProp", String);
            info.AddValue("ClassCProp", ClassCProp, typeof(ClassC));
        }
    }
}