using Languages;
using TMPro;
using UnityEngine;

namespace UI
{
    public class LanguageSelectionDropdown : MonoBehaviour
    {
        public TMP_Dropdown dropdown;

        private void Start()
        {
            // Add listener for when the value of the Dropdown changes, to take action
            dropdown.onValueChanged.AddListener(delegate {
                DropdownValueChanged(dropdown);
            });
        }

        // Output the new value of the Dropdown into Text
        private static void DropdownValueChanged(TMP_Dropdown change)
        {
            switch (change.value)
            {
                case 0:
                    LanguageManager.Instance.ActiveLanguage = Language.Portugues;
                    break;
                case 1:
                    LanguageManager.Instance.ActiveLanguage = Language.English;
                    break;
            }
        }
    }
}
