using Account;
using FridgeScripts;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ObjectAcceptButtonController : MonoBehaviour
    {
        [Header("UI's Animators")]
        public Animator popup;
        public Animator objectDisplay;
        public Animator objectDescription;
        public Animator hud;
        [Header("Controllers")]
        public ObjectDescriptionUiController objectDescriptionUiController;
        public FridgePlacementManipulator manipulator;

        private Button m_AcceptButton;

        private void Awake()
        {
            m_AcceptButton = GetComponent<Button>();
            m_AcceptButton.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            if (AccountsManager.Instance.isLoggedIn)
            {
                objectDisplay.Play("OD_Disabled");
                objectDescription.Play("ODESC_Exit");
                hud.Play("HUD_Enter");

                manipulator.fridgeInfo = objectDescriptionUiController.fridge;
            }
            else
            {
                popup.Play("POP_Enter");
            }
        }
    }
}