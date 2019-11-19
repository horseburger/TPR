using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bookstore
{
    public interface ICustomSerializable
    {
        string Serialization(ObjectIDGenerator idGen);
        void Deserialization(string[] data, Dictionary<int, Object> objDict);
    }
}