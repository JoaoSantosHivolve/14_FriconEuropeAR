using FridgeScripts;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Grids
{
    public class DisplayClick : MonoBehaviour
    {
        public Button button;
        public PopulateDisplayGrid grid;
        public Fridge fridge;
        public ObjectDescriptionUiController objectDescriptionUiController;
        public ObjectDescriptionColorPalletController colorPalletController;
        public ColorPalletButtonAnimationController colorPalletAnimationController;
        [Header("UI animators")]
        public Animator odAnimator;
        public Animator odescAnimator;

        private void Awake()
        {
            button = GetComponent<Button>();
        }
        private void Start()
        {
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            grid.SetInteractable(false);

            objectDescriptionUiController.OnEnter(fridge);

            odAnimator.Play("OD_Wait");
            odescAnimator.Play("ODESC_Enter");

            // Object description color pallet
            colorPalletController.FridgeImages = fridge.images;
            colorPalletController.OnClick(0);
            colorPalletAnimationController.OnClick(0);
        }
    }
}