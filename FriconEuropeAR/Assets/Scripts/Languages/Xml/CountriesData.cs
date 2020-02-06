using System.Xml.Serialization;

namespace Languages.Xml
{
    public static class CountriesData
    {
        public class Country
        {
            [XmlAttribute("name")] public string name;
            [XmlElement("Country")] public string country;
            [XmlElement("Person")] public string person;
            [XmlElement("Link")] public string link;
        }
    }
}