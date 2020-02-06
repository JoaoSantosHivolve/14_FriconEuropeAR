using System.Collections;
using TMPro;
using UI.Popup;
using UnityEngine;
using UnityEngine.UI;

namespace Account
{
    public class LoginController : MonoBehaviour
    {
        [Header("UI Animators")]
        public Animator loginAnimator;
        public Animator loadingIcon;
        public Animator loginPopup;
        [Header("Input fields")]
        public TMP_InputField nameField;
        public TMP_InputField passwordField;
        [Header("Login Button")]
        public Button button;
        [Header("Login Pop-Up Controller")]
        public LoginPopupController loginPopupController;

        public void CheckResults_OnClick()
        {
            loadingIcon.Play("LI_Loading");
            loginAnimator.Play("LOGIN_Loading");
            button.interactable = false;

            StartCoroutine(CheckValues());
        }

        private IEnumerator CheckValues()
        {
            yield return new WaitForSeconds(1f);

            button.interactable = true;
            var loginData = new LoginData()
            {
                email = nameField.text,
                password = passwordField.text
            };

            // Show popup
            loginPopup.Play("POP_Enter");

            if (AccountsManager.Instance.CanLogin(loginData))
            {
                // Info matches
                loadingIcon.Play("LI_Off");
                passwordField.text = "";
                loginAnimator.Play("LOGIN_Exit");

                var account = AccountsManager.Instance.GetAccount(loginData);
                loginPopupController.ShowInfo(LoginPopupController.LoginResult.Successful, account);

                AccountsManager.Instance.isLoggedIn = true;
                AccountsManager.Instance.loggedAccount = account;
            }
            else
            {
                // Info doesn't match
                loadingIcon.Play("LI_Off");
                passwordField.text = "";
                loginAnimator.Play("LOGIN_Waiting");

                // Show error message accordingly
                loginPopupController.ShowInfo(
                    AccountsManager.Instance.AccountIsInDataBase(loginData.email)
                        ? LoginPopupController.LoginResult.WrongInfo
                        : LoginPopupController.LoginResult.NoAccount, null);
            }
        }

        public void AllFieldsFilled_OnValueChanged()
        {
            button.interactable =
                nameField.text != ""
                && passwordField.text != "";
        }
    }
}