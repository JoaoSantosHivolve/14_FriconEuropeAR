using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ColorPalletButtonAnimationController : MonoBehaviour
    {
        public List<Button> buttons;

        public void OnClick(int index)
        {
            for (var i = 0; i < buttons.Count; i++)
            {
                buttons[i].transform.GetChild(0).GetComponent<Image>().enabled = i == index;
            }
        }
    }
}
