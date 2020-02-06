using System.Collections.Generic;
using System.Xml.Serialization;

//----- LANGUAGES -----
// 0 - Portugues
// 1 - English

namespace Languages.Xml
{
    [XmlRoot("LanguageTexts")]
    public class TextsCollection
    {
        [XmlArray("TextCountriesArray")]
        [XmlArrayItem("Language")]
        public List<TextsData.TextCountries> textsCountryNames = new List<TextsData.TextCountries>();

        [XmlArray("PopupMessageArray")]
        [XmlArrayItem("PopupMessage")]
        public List<TextsData.TextPopupMessage> textsPopupMessage = new List<TextsData.TextPopupMessage>();

        [XmlArray("LoginPopupMessageArray")]
        [XmlArrayItem("LoginPopupMessage")]
        public List<TextsData.TextLoginPopupMessage> textsLoginPopupMessage = new List<TextsData.TextLoginPopupMessage>();

        [XmlArray("RegistrationPopupMessageArray")]
        [XmlArrayItem("RegistrationPopupMessage")]
        public List<TextsData.TextRegistrationPopupMessage> textsRegistrationPopupMessage = new List<TextsData.TextRegistrationPopupMessage>();

        [XmlArray("LanguageSelectArray")]
        [XmlArrayItem("LanguageSelect")]
        public List<TextsData.TextLanguageSelect> textsLanguageSelect = new List<TextsData.TextLanguageSelect>();
        
        [XmlArray("TermsOfServiceArray")]
        [XmlArrayItem("TermsOfService")]
        public List<TextsData.TextTermsOfService> textsTermsOfService = new List<TextsData.TextTermsOfService>();

        [XmlArray("ObjectDisplayArray")]
        [XmlArrayItem("ObjectDisplay")]
        public List<TextsData.TextObjectDisplay> textsObjectDisplay = new List<TextsData.TextObjectDisplay>();

        [XmlArray("LoginSystemArray")]
        [XmlArrayItem("LoginSystem")]
        public List<TextsData.TextLoginSystem> textsLoginSystem = new List<TextsData.TextLoginSystem>();

        [XmlArray("RegisterSystemArray")]
        [XmlArrayItem("RegisterSystem")]
        public List<TextsData.TextRegisterSystem> textsRegisterSystem = new List<TextsData.TextRegisterSystem>();

        [XmlArray("ProfileMenuArray")]
        [XmlArrayItem("ProfileMenu")]
        public List<TextsData.TextProfileMenu> textsProfileMenu = new List<TextsData.TextProfileMenu>();

        [XmlArray("ObjectDescriptionArray")]
        [XmlArrayItem("ObjectDescription")]
        public List<TextsData.TextObjectDescription> textsObjectDescription = new List<TextsData.TextObjectDescription>();
    }
}