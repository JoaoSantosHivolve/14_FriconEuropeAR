using System;
using Account;
using TMPro;
using UnityEngine;

namespace UI.Popup
{
    public class LoginPopupController : MonoBehaviour
    {
        public enum LoginResult
        {
            Successful,
            WrongInfo,
            NoAccount
        }

        [Header("Title")] 
        public GameObject titleSuccessful;
        public GameObject titleWrongInfo;
        public GameObject titleNoAccount;
        [Header("Top Messages")]
        public GameObject topMessageSuccessful;
        public GameObject topMessageWrongInfo;
        public GameObject topMessageNoAccount;
        [Header("User name")]
        public TextMeshProUGUI userName;
        [Header("Bot Messages")]
        public GameObject botMessageSuccessful;
        public GameObject botMessageWrongInfo;
        public GameObject botMessageNoAccount;

        public void ShowInfo(LoginResult result, AccountData data)
        {
            // Hide show text accordingly
            SetText(result);

            // Set middle text
            userName.text = result == LoginResult.Successful ? data.firstName + " " + data.lastName : "";
        }

        private void SetText(LoginResult result)
        {
            // Title
            titleSuccessful.SetActive(result == LoginResult.Successful);
            titleWrongInfo.SetActive(result == LoginResult.WrongInfo);
            titleNoAccount.SetActive(result == LoginResult.NoAccount);

            // Top message
            topMessageSuccessful.SetActive(result == LoginResult.Successful);
            topMessageWrongInfo.SetActive(result == LoginResult.WrongInfo);
            topMessageNoAccount.SetActive(result == LoginResult.NoAccount);

            // Bot message
            botMessageSuccessful.SetActive(result == LoginResult.Successful);
            botMessageWrongInfo.SetActive(result == LoginResult.WrongInfo);
            botMessageNoAccount.SetActive(result == LoginResult.NoAccount);
        }
    }
}