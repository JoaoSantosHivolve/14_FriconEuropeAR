using System.Collections.Generic;
using System.Xml.Serialization;

namespace Languages.Xml
{
    public static class FridgesTextData
    {
        [XmlType("Fridge")]
        public class FridgeText
        {
            [XmlAttribute("FridgeName")] public string name;
            [XmlElement("GeneralInfo")] public string generalInfoName;
            // Language array
            [XmlArray("LanguagesArray")]
            [XmlArrayItem("Language")]
            public List<FridgeTextLanguage> languages = new List<FridgeTextLanguage>();
        }
        [XmlType("Language")]
        public class FridgeTextLanguage
        {
            [XmlAttribute("Language")] public string language;
            [XmlElement("RowsCount")] public int rowsCount;
            [XmlElement("ColumnsCount")] public int columnsCount;

            // Rows array
            [XmlArray("RowsArray")]
            [XmlArrayItem("Row")]
            public List<FridgeTextRow> rows = new List<FridgeTextRow>();
        }
        [XmlType("Row")]
        public class FridgeTextRow
        {
            [XmlAttribute("Index")] public int index;

            [XmlArray("RowElements")]
            [XmlArrayItem("Element")] 
            public List<FridgeTextRowElement> element = new List<FridgeTextRowElement>();
        }
        [XmlType("Element")]
        public class FridgeTextRowElement
        {
            [XmlAttribute("Column")] public string index;
            [XmlElement("Text")] public string text;
        }

        // ----- General Info
        [XmlType("GeneralInfo")]
        public class FridgeGeneralInfo
        {
            [XmlAttribute("Name")] public string name;

            [XmlArray("LanguagesArray")]
            [XmlArrayItem("GeneralInfoLanguage")]
            public List<GeneralInfoTextArray> languages = new List<GeneralInfoTextArray>();
        }
        [XmlType("GeneralInfoLanguage")]
        public class GeneralInfoTextArray
        {
            [XmlAttribute("Language")] public string language;

            [XmlArray("TextArray")]
            [XmlArrayItem("GeneralInfoText")]
            public List<GeneralInfoText> texts = new List<GeneralInfoText>();
        }
        [XmlType("GeneralInfoText")]
        public class GeneralInfoText
        {
            [XmlAttribute("Index")] public string index;
            [XmlElement("TextTitle")] public string textTitle;
            [XmlElement("TextDetails")] public string textDetails;
        }
    }
}
