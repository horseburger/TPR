using System;
using System.Collections.Generic;
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DateProp", Date);
            info.AddValue("FloatProp", Float);
            info.AddValue("StringProp", String);
            info.AddValue("ClassCProp", ClassCProp, typeof(ClassC));
        }

        public string toString()
        {
            return "" + Date.ToShortDateString() + Float + String + ClassCProp.toString() + "";
        }

        public override bool Equals(object obj)
        {
            return obj is ClassB b &&
                   Date == b.Date &&
                   Float == b.Float &&
                   String == b.String &&
                   EqualityComparer<ClassC>.Default.Equals(ClassCProp, b.ClassCProp);
        }

        public override int GetHashCode()
        {
            var hashCode = -1687280373;
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            hashCode = hashCode * -1521134295 + Float.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(String);
            hashCode = hashCode * -1521134295 + EqualityComparer<ClassC>.Default.GetHashCode(ClassCProp);
            return hashCode;
        }
    }
}