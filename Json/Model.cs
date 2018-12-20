using System;
using System.Runtime.Serialization;

namespace Json
{
    [DataContract]
    public class Model
    {
        [DataMember]
        public string Prop1 {get;set;}
        [DataMember]
        public string Prop2 {get;set;}
    }
}
