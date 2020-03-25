using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace WeatherModels
{    
    [DataContract]
    public class TemperatureModel
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "weather")]
        public IEnumerable<WeatherDescription> Weather { get; set; }

        [DataMember]
        public Main Main { get; set; }
    }

    [DataContract]
    public class WeatherDescription
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
    }

    [DataContract]
    public class Main
    {
        [DataMember(Name = "temp")]
        public string Temp { get; set; }
    }
    
}
