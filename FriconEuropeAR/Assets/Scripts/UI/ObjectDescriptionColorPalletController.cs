using System.Collections.Generic;
using FridgeScripts;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ObjectDescriptionColorPalletController : MonoBehaviour
    {
        public List<Button> buttons;
        public Image image;
    
        private Sprite[] m_FridgeImages;
        public Sprite[] FridgeImages
        {
            get { return m_FridgeImages; }
            set
            {
                m_FridgeImages = value;
                if (value.Length < 5)
                {
                    Debug.LogWarning("Object has less than 5 images!");
                }
            }
        }

        private void Start()
        {
            for (var i = 0; i < FridgeMaterialsManager.Instance.fridgeColors.Count; i++)
            {
                buttons[i].image.color = FridgeMaterialsManager.Instance.fridgeColors[i].squareColor;
            }
        }

        public void OnClick(int index)
        {
            image.sprite = FridgeImages[index];
            image.color = FridgeMaterialsManager.Instance.fridgeColors[index].squareColor;
        }
    }
}
