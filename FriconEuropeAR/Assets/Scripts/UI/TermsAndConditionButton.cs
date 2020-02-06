using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TermsAndConditionButton : MonoBehaviour
    {
        public Button button;
        public TextMeshProUGUI buttonText;
        public Button acceptButton;

        private bool m_State;

        private void Start()
        {
            button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            m_State = !m_State;
            acceptButton.interactable = m_State;
            buttonText.text = m_State ? "X" : "";
        }
    }
}
