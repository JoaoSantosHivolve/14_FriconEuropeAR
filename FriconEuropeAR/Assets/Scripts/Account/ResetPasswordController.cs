using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Account
{
    public class ResetPasswordController : MonoBehaviour
    {
        public TMP_InputField inputField;
        public MailSender mailSender;
        public Button resetButton;

        public void ResetPassword_OnClick()
        {
            var email = inputField.text;

            if (AccountsManager.Instance.AccountIsInDataBase(email))
            {
                // Generate new password
                var newPassword = GenerateNewPassword();

                // Update account password
                var newLoginData = new LoginData()
                {
                    email = email,
                    password = newPassword
                };
                AccountsManager.Instance.ResetPassword(newLoginData);
                
                // Send email
                StartCoroutine(mailSender.SendResetPasswordEmail(newLoginData));

                // Update popup message
                Debug.Log("Password Reset");
            }
            else
            {
                // Update popup message
                Debug.Log("Account not in database");
            }

            // Reset input text
            inputField.text = "";
        }

        public string GenerateNewPassword()
        {
            var password = Random.Range(0, 999999);
            return password.ToString();
        }

        public void EmailInputFilled_OnValueChanged()
        {
            resetButton.interactable = inputField.text != "";
        }
    }
}
