using System;
using System.Collections.Generic;
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

        public string toString()
        {
            return "" + Date.ToShortDateString() + Float + String + "";
        }

        public override bool Equals(object obj)
        {
            return obj is ClassC c &&
                   Date == c.Date &&
                   Float == c.Float &&
                   String == c.String;
        }

        public override int GetHashCode()
        {
            var hashCode = -339614575;
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            hashCode = hashCode * -1521134295 + Float.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(String);
            
            return hashCode;
        }
    }
}