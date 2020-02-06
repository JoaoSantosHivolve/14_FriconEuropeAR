using System.Collections.Generic;
using System.Xml.Serialization;

namespace Languages.Xml
{
    public static class TextsData
    {
        // 0 - Countries
        public class TextCountries
        {
            [XmlAttribute("language")] public string language;
            [XmlArray("CountriesArray")]
            [XmlArrayItem("Country")]
            public List<TextCountry> countries = new List<TextCountry>();
        }
        [XmlType("Country")]
        public class TextCountry
        {
            [XmlAttribute("name")] public string name;
            [XmlElement("CountryName")] public string countryName;
        }
        // 0 - Popup Message
        public class TextPopupMessage
        {
            [XmlAttribute("language")] public string language;
            [XmlElement("Title")] public string title;
            [XmlElement("Message")] public string message;
        }
        // 0 - Registration Popup Message 
        public class TextLoginPopupMessage
        {
            [XmlAttribute("language")] public string language;
            [XmlElement("TitleSuccessful")] public string titleSuccessful;
            [XmlElement("TitleWrongInfo")]  public string titleWrongInfo;
            [XmlElement("TitleNoAccount")]  public string titleNoAccount;
            [XmlElement("TopMessageSuccessful")] public string topMessageSuccessful;
            [XmlElement("TopMessageWrongInfo")]  public string topMessageWrongInfo;
            [XmlElement("TopMessageNoAccount")]  public string topMessageNoAccount;
            [XmlElement("BotMessageSuccessful")] public string botMessageSuccessful;
            [XmlElement("BotMessageWrongInfo")]  public string botMessageWrongInfo;
            [XmlElement("BotMessageNoAccount")]  public string botMessageNoAccount;
        }
        // 0 - Registration Popup Message 
        public class TextRegistrationPopupMessage
        {
            [XmlAttribute("language")] public string language;
            [XmlElement("TitleSuccessful")] public string titleSuccessful;
            [XmlElement("TitleInvalid")] public string titleInvalid;
            [XmlElement("MessageSuccessful")] public string messageSuccessful;
            [XmlElement("MessageInvalid")] public string messageInvalid;
        }
        // 1 - Language Select
        public class TextLanguageSelect
        {
            [XmlAttribute("language")] public string language;
            [XmlElement("Title")] public string title;
            [XmlElement("Button")] public string button;
        }
        // 2 - Terms of Service
        public class TextTermsOfService
        {
            [XmlAttribute("language")] public string language;
            [XmlElement("Title")] public string title;
            [XmlElement("Terms")] public string terms;
            [XmlElement("AcceptTerms")] public string acceptTerms;
            [XmlElement("Button")] public string button;
        }
        // 4 - Object display
        public class TextObjectDisplay
        {
            [XmlAttribute("language")] public string language;
            [XmlElement("Reseller")] public string reseller;
            [XmlElement("Marketplace")] public string marketplace;
        }
        // 5 - Login System
        public class TextLoginSystem
        {
            [XmlAttribute("language")] public string language;
            [XmlElement("Title")] public string title;
            [XmlElement("Email")] public string email;
            [XmlElement("EnterEmail")] public string enterEmail;
            [XmlElement("Password")] public string password;
            [XmlElement("EnterPassword")] public string enterPassword;
            [XmlElement("ForgotPassword")] public string forgotPassword;
            [XmlElement("Register")] public string register;
            [XmlElement("Error")] public string error;
        }
        // 5 - Register System
        public class TextRegisterSystem
        {
            [XmlAttribute("language")] public string language;
            [XmlElement("Title")] public string title;
            [XmlElement("FirstName")] public string firstName;
            [XmlElement("EnterFirstName")] public string enterFirstName;
            [XmlElement("LastName")] public string lastName;
            [XmlElement("EnterLastName")] public string enterLastName;
            [XmlElement("SelectCountry")] public string selectCountry;
            [XmlElement("Company")] public string company;
            [XmlElement("EnterCompany")] public string enterCompany;
            [XmlElement("Email")] public string email;
            [XmlElement("EnterEmail")] public string enterEmail;
            [XmlElement("Password")] public string password;
            [XmlElement("EnterPassword")] public string enterPassword;
            [XmlElement("Button")] public string button;
        }
        // 5 - Profile menu
        public class TextProfileMenu
        {
            [XmlAttribute("language")] public string language;
            [XmlElement("Title")] public string title;
            [XmlElement("ChangePassword")] public string changePassword;
            [XmlElement("EnterPassword")] public string enterPassword;
            [XmlElement("ChangeLanguage")] public string changeLanguage;
            [XmlElement("Button")] public string button;
        }
        // 6 - Object Description
        public class TextObjectDescription
        {
            [XmlAttribute("language")] public string language;
            [XmlElement("Details")] public string details;
            [XmlElement("GeneralInfo")] public string generalInfo;
        }
    }
}