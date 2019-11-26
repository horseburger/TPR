using System;
using System.Runtime.Serialization;

namespace CustomSerializer.UnitTest
{
    public class ClassC : ISerializable
    {
        public DateTime Date { get; set; }
        public float Float { get; set; }
        public string String { get; set; }
        public ClassA ClassAProp { get; set; }

        public ClassC(DateTime date, float f, string s, ClassA classAProp)
        {
            Date = date;
            Float = f;
            String = s;
            ClassAProp = classAProp;
        }

        public ClassC(SerializationInfo info, StreamingContext context)
        {
            Date = info.GetDateTime("DateProp");
            Float = info.GetSingle("FloatProp");
            String = info.GetString("StringProp");
            ClassAProp = (ClassA) info.GetValue("ClassAProp", typeof(ClassA));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DateProp", Date);
            info.AddValue("FloatProp", Float);
            info.AddValue("StringProp", String);
            info.AddValue("ClassAProp", ClassAProp, typeof(ClassA));
        }

        public override bool Equals(object obj)
        {
            return obj is ClassC c &&
                   Date.Equals(c.Date) &&
                   Float.Equals(c.Float) &&
                   String.Equals(c.String) &&
                   ClassAProp == c.ClassAProp;
        }
    }
}