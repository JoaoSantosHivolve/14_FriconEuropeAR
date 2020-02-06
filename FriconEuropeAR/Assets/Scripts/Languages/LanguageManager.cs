using Assets.Scripts.Common;
using Languages.Xml;
using TMPro;
using UnityEngine;

namespace Languages
{
    public enum Language
    {
        Portugues,
        English
    }

    public class LanguageManager : Singleton<LanguageManager>
    {
        private Language m_ActiveLanguage;
        public Language ActiveLanguage
        {
            get { return m_ActiveLanguage; }
            set
            { 
                m_ActiveLanguage = value;
                UpdateText();
            }
        }

        public TextsCollection texts;

        [Header("0-Popup")] 
        public TextMeshProUGUI popTitle;
        public TextMeshProUGUI popMessage;
        [Header("0-Login Popup")] 
        public TextMeshProUGUI logPopTitleSuccessful;
        public TextMeshProUGUI logPopTitleWrongInfo;
        public TextMeshProUGUI logPopTitleNoAccount;
        public TextMeshProUGUI logPopTopMessageSuccessful;
        public TextMeshProUGUI logPopTopMessageWrongInfo;
        public TextMeshProUGUI logPopTopMessageNoAccount;
        public TextMeshProUGUI logPopBotMessageSuccessful;
        public TextMeshProUGUI logPopBotMessageWrongInfo;
        public TextMeshProUGUI logPopBotMessageNoAccount;
        [Header("0-Registration Popup")]
        public TextMeshProUGUI regPopTitleSuccessful;
        public TextMeshProUGUI regPopTitleInvalid;
        public TextMeshProUGUI regPopMessageSuccessful;
        public TextMeshProUGUI regPopMessageInvalid;
        [Header("1-Language Select")] 
        public TextMeshProUGUI lsTitle;
        public TextMeshProUGUI lsButton;
        [Header("2-Terms of Service")] 
        public TextMeshProUGUI tsTitle;
        public TextMeshProUGUI tsTerms;
        public TextMeshProUGUI tsAcceptTerms;
        public TextMeshProUGUI tsButton;
        [Header("4-Object Display")]
        public TextMeshProUGUI odReseller;
        public TextMeshProUGUI odMarketplace;
        [Header("5-Login System")] 
        public TextMeshProUGUI loginTitle;
        public TextMeshProUGUI loginEmail;
        public TextMeshProUGUI loginEnterEmail;
        public TextMeshProUGUI loginPassword;
        public TextMeshProUGUI loginEnterPassword;
        public TextMeshProUGUI loginForgotPassword;
        public TextMeshProUGUI loginRegister;
        [Header("5-Login System")]
        public TextMeshProUGUI registerTitle;
        public TextMeshProUGUI registerFirstName;
        public TextMeshProUGUI registerEnterFirstName;
        public TextMeshProUGUI registerLastName;
        public TextMeshProUGUI registerEnterLastName;
        public TextMeshProUGUI registerSelectCountry;
        public TextMeshProUGUI registerCompany;
        public TextMeshProUGUI registerEnterCompany;
        public TextMeshProUGUI registerEmail;
        public TextMeshProUGUI registerEnterEmail;
        public TextMeshProUGUI registerPassword;
        public TextMeshProUGUI registerEnterPassword;
        public TextMeshProUGUI registerButton;
        [Header("5-Profile Menu")]
        public TextMeshProUGUI profileTitle;
        public TextMeshProUGUI profileChangePassword;
        public TextMeshProUGUI profileEnterPassword;
        public TextMeshProUGUI profileChangeLanguage;
        public TextMeshProUGUI profileButton;
        [Header("6-Object Description")] 
        public TextMeshProUGUI objDetails;
        public TextMeshProUGUI objGeneralInfo;

        private void Start()
        {
            // Set default language
            ActiveLanguage = Language.Portugues;
        }

        private void UpdateText()
        {
            var index = (int)ActiveLanguage;

            // 0 - Popup
            var pop = texts.textsPopupMessage[index];
            popTitle.text = pop.title;
            popMessage.text = pop.message;

            // 0 - Login Popup
            var logPop = texts.textsLoginPopupMessage[index];
            logPopTitleSuccessful.text = logPop.titleSuccessful;
            logPopTitleWrongInfo.text = logPop.titleWrongInfo;
            logPopTitleNoAccount.text = logPop.titleNoAccount;
            logPopTopMessageSuccessful.text = logPop.topMessageSuccessful;
            logPopTopMessageWrongInfo.text = logPop.topMessageWrongInfo;
            logPopTopMessageNoAccount.text = logPop.topMessageNoAccount;
            logPopBotMessageSuccessful.text = logPop.botMessageSuccessful;
            logPopBotMessageWrongInfo.text = logPop.botMessageWrongInfo;
            logPopBotMessageNoAccount.text = logPop.botMessageNoAccount;

            // 0 - Registration Popup
            var regPop = texts.textsRegistrationPopupMessage[index];
            regPopTitleSuccessful.text = regPop.titleSuccessful;
            regPopTitleInvalid.text = regPop.titleInvalid;
            regPopMessageSuccessful.text = regPop.messageSuccessful;
            regPopMessageInvalid.text = regPop.messageInvalid;
            
            // 1 - Language Selection
            var ls = texts.textsLanguageSelect[index];
            lsTitle.text = ls.title;
            lsButton.text = ls.button;

            // 2 - Terms of Service
            var ts = texts.textsTermsOfService[index];
            tsTitle.text = ts.title;
            tsTerms.text = ts.terms;
            tsAcceptTerms.text = ts.acceptTerms;
            tsButton.text = ts.button;

            // 4 - Object Display
            var od = texts.textsObjectDisplay[index];
            odMarketplace.text = od.marketplace;
            odReseller.text = od.reseller;

            // 5 - Login System
            var login = texts.textsLoginSystem[index];
            loginTitle.text = login.title;
            loginEmail.text = login.email;
            loginEnterEmail.text = login.email;
            loginPassword.text = login.password;
            loginEnterPassword.text = login.enterPassword;
            loginForgotPassword.text = login.forgotPassword;
            loginRegister.text = login.register;

            // 5 - Register System
            var register = texts.textsRegisterSystem[index];
            registerTitle.text = register.title;
            registerFirstName.text = register.firstName;
            registerEnterFirstName.text = register.enterFirstName;
            registerLastName.text = register.lastName;
            registerEnterLastName.text = register.enterLastName;
            registerSelectCountry.text = register.selectCountry;
            registerCompany.text = register.company;
            registerEnterCompany.text = register.enterCompany;
            registerEmail.text = register.email;
            registerEnterEmail.text = register.enterEmail;
            registerPassword.text = register.password;
            registerEnterPassword.text = register.enterPassword;
            registerButton.text = register.button;

            // 5 - Profile menu
            var profile = texts.textsProfileMenu[index];
            profileTitle.text = profile.title;
            profileChangePassword.text = profile.changePassword;
            profileEnterPassword.text = profile.enterPassword;
            profileChangeLanguage.text = profile.changeLanguage;
            profileButton.text = profile.button;

            // 6 - Object Display
            var obj = texts.textsObjectDescription[index];
            objDetails.text = obj.details;
            objGeneralInfo.text = obj.generalInfo;
        }
    }
}