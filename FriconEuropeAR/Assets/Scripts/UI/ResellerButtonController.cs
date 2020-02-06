using Account;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ResellerButtonController : MonoBehaviour
    {
        public Button resellerButton;
        public Animator popupAnimator;

        private void Awake()
        {
            resellerButton.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            if (AccountsManager.Instance.isLoggedIn)
            {
                var loggedAccount = AccountsManager.Instance.loggedAccount;
                var country = AccountsManager.Instance.GetCountryInfo(loggedAccount);

                Application.OpenURL(country.link);
            }
            else
            {
                popupAnimator.Play("POP_Enter");
            }
        }
    }
}
