using System;
using System.Collections.Generic;
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

        public string toString()
        {
            return "" + Date.ToShortDateString() + Float + String + ClassBProp.toString() + "";
        }

        public override bool Equals(object obj)
        {
            return obj is ClassA a &&
                   Date == a.Date &&
                   Float == a.Float &&
                   String == a.String &&
                   EqualityComparer<ClassB>.Default.Equals(ClassBProp, a.ClassBProp);
        }

        public override int GetHashCode()
        {
            var hashCode = -644236024;
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            hashCode = hashCode * -1521134295 + Float.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(String);
            hashCode = hashCode * -1521134295 + EqualityComparer<ClassB>.Default.GetHashCode(ClassBProp);
            return hashCode;
        }
    }
}