using FridgeScripts;
using Grids;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ObjectDescriptionUiController : MonoBehaviour
    {
        [Header("Buttons")]
        public Button details;
        public Button generalInfo;
        public GameObject detailsScrollView;
        public GameObject generalInfoScrollView;
        public PopulateDetailsGrid detailsGrid;
        public PopulateGeneralInfoGrid generalInfoGrid;

        [Space(10)] 
        [Header("Fridge name text")]
        public TextMeshProUGUI fridgeName;
        public Fridge fridge;

        private readonly Color m_Transparent = new Color(1, 1, 1, 0.5f);

        private void Start()
        {
            details.onClick.AddListener(Description_OnClick);
            generalInfo.onClick.AddListener(GeneralInfo_OnClick);

            Description_OnClick();
        }

        public void OnEnter(Fridge selectedFridge)
        {
            fridge = selectedFridge;

            fridgeName.text = fridge.name;

            Description_OnClick();
            detailsGrid.Populate(fridge.name);
            generalInfoGrid.Populate(fridge.name);
        }


        private void Description_OnClick()
        {
            detailsScrollView.SetActive(true);
            generalInfoScrollView.SetActive(false);

            details.transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Underline;
            generalInfo.transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
            details.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
            generalInfo.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = m_Transparent;
        }
        private void GeneralInfo_OnClick()
        {
            detailsScrollView.SetActive(false);
            generalInfoScrollView.SetActive(true);

            details.transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
            generalInfo.transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Underline;
            details.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = m_Transparent;
            generalInfo.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }
}