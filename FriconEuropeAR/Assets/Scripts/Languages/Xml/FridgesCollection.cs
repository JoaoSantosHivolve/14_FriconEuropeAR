using System.Collections.Generic;
using System.Xml.Serialization;

namespace Languages.Xml
{
    [XmlRoot("FridgesData")]
    public class FridgesCollection
    {
        [XmlArray("FridgesArray")]
        [XmlArrayItem("Fridge")]
        public List<FridgesTextData.FridgeText> infoFridges = new List<FridgesTextData.FridgeText>();

        [XmlArray("GeneralInfoArray")]
        [XmlArrayItem("GeneralInfo")]
        public List<FridgesTextData.FridgeGeneralInfo> generalInfo = new List<FridgesTextData.FridgeGeneralInfo>();
    }
}