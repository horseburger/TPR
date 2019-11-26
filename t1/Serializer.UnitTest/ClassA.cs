using System;
using System.Runtime.Serialization;

namespace CustomSerializer.UnitTest
{
    public class ClassA : ISerializable
    {
        public DateTime Date { get; set; }
        public float Float { get; set; }
        public string String { get; set; }
        public ClassB ClassBProp { get; set; }
        

        public ClassA(DateTime date, float f, string s, ClassB classBProp)
        {
            Date = date;
            Float = f;
            String = s;
            ClassBProp = classBProp;
        }

        public override bool Equals(object obj)
        {
            return obj is ClassA a &&
                   Date.Equals(a.Date) &&
                   Float.Equals(a.Float) &&
                   String.Equals(a.String) &&
                   ClassBProp == a.ClassBProp;

        }

        public ClassA(SerializationInfo info, StreamingContext context)
        {
            Date = info.GetDateTime("DateProp");
            Float = info.GetSingle("FloatProp");
            String = info.GetString("StringProp");
            ClassBProp = (ClassB) info.GetValue("ClassBProp", typeof(ClassB));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DateProp", Date);
            info.AddValue("FloatProp", Float);
            info.AddValue("StringProp", String);
            info.AddValue("ClassBProp", ClassBProp, typeof(ClassB));
        }
    }
}