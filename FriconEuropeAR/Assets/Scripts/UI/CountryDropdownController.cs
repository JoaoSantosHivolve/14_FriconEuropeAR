using System.Collections.Generic;
using Languages.Xml;
using TMPro;
using UnityEngine;

namespace UI
{
    public class CountryDropdownController : MonoBehaviour
    {
        public TMP_Dropdown dropdown;

        public void UpdateDropdown()
        {
            dropdown.ClearOptions();

            var listOptions = new List<string>();

            foreach (var data in XmlLoader.Instance.Countries.dataCountries)
            {
                listOptions.Add(data.country);
            }

            // BUG: Dropdown never shows last item, so this one
            // BUG: is added so the client can see all options
            // BUG: Needs a better fix
            listOptions.Add("debugItem");

            dropdown.AddOptions(listOptions);
            dropdown.RefreshShownValue();
        }
    }
}