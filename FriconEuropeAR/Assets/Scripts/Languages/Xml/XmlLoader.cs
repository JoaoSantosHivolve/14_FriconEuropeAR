using System.IO;
using System.Xml.Serialization;
using Assets.Scripts.Common;
using UnityEngine;

namespace Languages.Xml
{
    public class XmlLoader : Singleton<XmlLoader>
    {
        public const string k_Path = "LTexts";
        public const string k_CountriesPath = "LCountries";
        public const string k_FridgesPath = "LFridgeInfoTexts";

        private TextsCollection m_Texts = new TextsCollection();
        public TextsCollection Texts
        {
            get { return m_Texts; }
            set
            {
                m_Texts = value;
                LanguageManager.Instance.texts = value;
            }
        }

        public CountriesCollection Countries
        {
            get { return LoadCountries(k_CountriesPath); }
        }

        public FridgesCollection fridges;

        private void Start()
        {
            Texts = Load(k_Path);
            fridges = LoadFridges();
        }

        public static TextsCollection Load(string path)
        {
            var xml = Resources.Load<TextAsset>(path);
            var serializer = new XmlSerializer(typeof(TextsCollection));
            var reader = new StringReader(xml.text);
            var texts = serializer.Deserialize(reader) as TextsCollection;

            reader.Close();

            return texts;
        }
        public CountriesCollection LoadCountries(string path)
        {
            var xml = Resources.Load<TextAsset>(path);
            var serializer = new XmlSerializer(typeof(CountriesCollection));
            var reader = new StringReader(xml.text);
            var data = serializer.Deserialize(reader) as CountriesCollection;
            var index = (int)LanguageManager.Instance.ActiveLanguage;

            for (var i = 0; i < data.dataCountries.Count; i++)
            {
                data.dataCountries[i].country = Texts.textsCountryNames[index].countries[i].countryName;
            }

            reader.Close();

            return data;
        }
        public FridgesCollection LoadFridges()
        {
            var xml = Resources.Load<TextAsset>(k_FridgesPath);
            var serializer = new XmlSerializer(typeof(FridgesCollection));
            var reader = new StringReader(xml.text);
            var data = serializer.Deserialize(reader) as FridgesCollection;

            reader.Close();

            return data;
        }
        public FridgesTextData.FridgeTextLanguage GetFridge(string fridgeName)
        {
            var index = (int)LanguageManager.Instance.ActiveLanguage;

            for (var i = 0; i < fridges.infoFridges.Count; i++)
            {
                if (fridges.infoFridges[i].name == fridgeName)
                {
                    return fridges.infoFridges[i].languages[index];
                }
            }

            Debug.LogWarning("No fridge text found!");
            return null;
        }
        public FridgesTextData.GeneralInfoTextArray GetGeneralInfo(string fridgeName)
        {
            var index = (int)LanguageManager.Instance.ActiveLanguage;

            string generalInfoName = "";

            for (var i = 0; i < fridges.infoFridges.Count; i++)
            {
                if (fridges.infoFridges[i].name == fridgeName)
                {
                    generalInfoName = fridges.infoFridges[i].generalInfoName;
                }
            }

            for (int i = 0; i < fridges.generalInfo.Count; i++)
            {
                if (fridges.generalInfo[i].name == generalInfoName)
                    return fridges.generalInfo[i].languages[index];
            }

            return null;
        }
    }
}
