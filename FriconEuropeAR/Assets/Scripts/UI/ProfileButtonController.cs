using Account;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ProfileButtonController : MonoBehaviour
    {
        public Button button;
        public Animator loginAnimator;
        public Animator profileAnimator;

        private void Awake()
        {
            button.onClick.AddListener(OpenProfile);
        }

        private void OpenProfile()
        {
            if (AccountsManager.Instance.isLoggedIn)
            {
                profileAnimator.Play("PROFILE_Enter");
            }
            else
            {
                loginAnimator.Play("LOGIN_Enter");
            }
        }
    }
}
