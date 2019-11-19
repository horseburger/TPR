using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bookstore
{
    public interface ISerializer
    {
        string Serialization(ObjectIDGenerator id);
        void Deserialization(string[] data);
    }
}