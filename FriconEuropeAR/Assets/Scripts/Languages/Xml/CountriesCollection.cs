using System.Collections.Generic;
using System.Xml.Serialization;

namespace Languages.Xml
{
    [XmlRoot("CountriesData")]
    public class CountriesCollection
    {
        [XmlArray("CountriesArray")]
        [XmlArrayItem("Country")]
        public List<CountriesData.Country> dataCountries = new List<CountriesData.Country>();
    }
}