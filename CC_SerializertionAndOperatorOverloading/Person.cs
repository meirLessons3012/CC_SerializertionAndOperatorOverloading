using System.Text.Json;
using System.Xml.Serialization;

namespace CC_SerializertionAndOperatorOverloading
{
    [XmlRoot("Man")]
    public class Person
    {
        [XmlAttribute]
        public int Id { get; set; }
        
        [XmlElement("FName")] 
        public string FirstName { get; set; }
        
        [XmlElement("LName")]
        public string LastName { get; set; }

        [XmlIgnore]
        public string  PhonePsw { get; set; }

        public Person()
        {
            
        }
    }
}