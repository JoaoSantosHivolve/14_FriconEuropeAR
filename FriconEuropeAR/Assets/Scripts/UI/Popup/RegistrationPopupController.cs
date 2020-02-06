using System;
using UnityEngine;

namespace UI.Popup
{
    public class RegistrationPopupController : MonoBehaviour
    {
        public enum Result
        {
            Successful,
            InvalidInfo,
        }

        public GameObject titleSuccessful;
        public GameObject titleInvalid;
        public GameObject messageSuccessful;
        public GameObject messageInvalidInfo;


        public void ShowInfo(Result result)
        {
            switch (result)
            {
                case Result.Successful:
                    titleSuccessful.SetActive(true);
                    titleInvalid.SetActive(false);
                    messageSuccessful.SetActive(true);
                    messageInvalidInfo.SetActive(false);
                    break;
                case Result.InvalidInfo:
                    titleSuccessful.SetActive(false);
                    titleInvalid.SetActive(true);
                    messageSuccessful.SetActive(false);
                    messageInvalidInfo.SetActive(true);
                    break;
            }
        }
    }
}
