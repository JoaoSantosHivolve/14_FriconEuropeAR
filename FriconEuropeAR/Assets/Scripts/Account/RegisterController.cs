using System.Collections;
using TMPro;
using UI.Popup;
using UnityEngine;
using UnityEngine.UI;

namespace Account
{
    public class RegisterController : MonoBehaviour
    {
        [Header("Register animator")] 
        public Animator register;
        [Header("Input elements")]
        public TMP_InputField firstName;
        public TMP_InputField lastName;
        public TMP_Dropdown country;
        public TMP_InputField company;
        public TMP_InputField email;
        public TMP_InputField password;
        [Header("Register Button")] 
        public Button button;
        [Header("Loading Icon")] 
        public Animator icon;
        [Header("Registration popup")] 
        public Animator popup;
        public RegistrationPopupController popupController;

        public void AllFieldsFilled_OnValueChanged()
        {
            button.interactable =
                firstName.text != ""
                && lastName.text != ""
                && company.text != ""
                && email.text != ""
                && password.text != "";
        }
        public void Register_OnClick()
        {
            // Icon loading animation
            icon.Play("LI_Loading");
            // Lock all input fields anim
            register.Play("REGISTER_Loading");
            // Lock button
            button.interactable = false;
            // Check registration info
            StartCoroutine(CheckRegistration());
        }

        private void ClearInfo()
        {
            firstName.text = "";
            lastName.text = "";
            company.text = "";
            email.text = "";
            password.text = "";
        }
        private IEnumerator CheckRegistration()
        {
            yield return new WaitForSeconds(1.5f);

            // Unlock button
            button.interactable = true;

            // Stop loading icon
            icon.Play("LI_Off");

            // Show popup message
            popup.Play("POP_Enter");

            var manager = AccountsManager.Instance;

            // Info matches
            if (manager.CanCreateAccount(GetData()))
            {
                // Exit registration Page
                register.Play("REGISTER_Exit");

                // Register new account to json file
                AccountsManager.Instance.CreateAccount(GetData());

                // Show popup info
                popupController.ShowInfo(RegistrationPopupController.Result.Successful);

                // Delete inserted info
                ClearInfo();
            }
            // Info not valid
            else
            {
                // Reset animations
                register.Play("REGISTER_Waiting");

                // Show popup info
                popupController.ShowInfo(RegistrationPopupController.Result.InvalidInfo);
            }
        }
        private AccountData GetData()
        {
            var data = new AccountData()
            {
                firstName = this.firstName.text,
                lastName = this.lastName.text,
                country = this.country.value,
                company = this.company.text,
                email = this.email.text,
                password = this.password.text
            };

            return data;
        }
    }
}