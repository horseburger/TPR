using System;
using System.Diagnostics;
using System.IO;
using Bookstore;
using NUnit.Framework;

namespace CustomSerializer.UnitTest
{
    public class OwnSerializationTest
    {
        private Serializer serializer;
        const string filename = "OwnTest";
        private ClassA A;
        private ClassB B;
        private ClassC C;

        [SetUp]
        public void Setup()
        {
            A = new ClassA(DateTime.Now, 0.99f, "Class\" A", null);
            B = new ClassB(DateTime.Now, 1.20f, "Class B", null);
            C = new ClassC(DateTime.Now, 9.99f, "Class C", null);
            A.ClassBProp = B;
            B.ClassCProp = C;
            C.ClassAProp = A;
            serializer = new Serializer();
            if (!File.Exists(filename))
            {
                File.Create(filename).Dispose();
            }
        }

        [Test]
        public void ClassASerialAndDeserial()
        {
            serializer.Serialize(new FileStream(filename + "A", FileMode.Create), A);

            ClassA newA = (ClassA) serializer.Deserialize(new FileStream(filename + "A", FileMode.Open));
            Assert.IsTrue(newA.Equals(A));
            Assert.IsTrue(newA.ClassBProp.ClassCProp.ClassAProp == newA);
        }

        [Test]
        public void ClassBSerialAndDeserial()
        {
            serializer.Serialize(new FileStream(filename + "B", FileMode.Create), B);

            ClassB newB = (ClassB) serializer.Deserialize(new FileStream(filename + "B", FileMode.Open));
            Assert.IsTrue(newB.ClassCProp.ClassAProp.ClassBProp == newB);
        }
    }
}
