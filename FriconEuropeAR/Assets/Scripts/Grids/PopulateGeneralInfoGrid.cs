using System.Collections;
using System.Collections.Generic;
using Languages.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Grids
{
    public class PopulateGeneralInfoGrid : MonoBehaviour
    {
        [Header("Grid Elements")]
        public GameObject prefab;
        public RectTransform scrollView;
        public RectTransform content;

        public List<Sprite> icons;

        private List<GameObject> m_GridElements = new List<GameObject>();

        public void Populate(string fridgeName)
        {
            ClearGrid();

            var width = scrollView.rect.width;

            for (var i = 0; i < 5; i++)
            {
                // Create element
                var newObj = Instantiate(prefab, transform);

                // Get text info
                var generalInfo = XmlLoader.Instance.GetGeneralInfo(fridgeName);
                var title = generalInfo.texts[i].textTitle;
                var details = generalInfo.texts[i].textDetails;
                newObj.GetComponent<TextMeshProUGUI>().text =
                    "<size=75>" + title + "</size>\n<size=55>" + details + "</size>";

                // Add text and sprite
                newObj.transform.GetChild(0).GetComponent<Image>().sprite = icons[i];

                // Set newObject Size
                var sD = newObj.GetComponent<RectTransform>().sizeDelta;
                newObj.GetComponent<RectTransform>().sizeDelta = new Vector2(width, sD.y);

                // Add element to list
                m_GridElements.Add(newObj);
            }
        }

        private void OnEnable()
        {
            StartCoroutine(SetGridElementsPosition());
        }

        private IEnumerator SetGridElementsPosition()
        {
            yield return new WaitForEndOfFrame();

            float heightIncrement = 0;

            for (var i = 0; i < m_GridElements.Count; i++)
            {
                var aPos = m_GridElements[i].GetComponent<RectTransform>().anchoredPosition;
                m_GridElements[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(aPos.x, -heightIncrement);

                // Disable content fitter
                m_GridElements[i].GetComponent<ContentSizeFitter>().enabled = false;

                // Get image size
                var imageSize = m_GridElements[i].transform.GetChild(0).GetComponent<RectTransform>().sizeDelta;
                var elementSize = m_GridElements[i].GetComponent<RectTransform>().sizeDelta;
                if(imageSize.y > elementSize.y)
                    m_GridElements[i].GetComponent<RectTransform>().sizeDelta = new Vector2(elementSize.x, imageSize.y);

                // Increment Height
                heightIncrement += m_GridElements[i].GetComponent<RectTransform>().rect.height;
            }

            // Set content size
            content.sizeDelta = new Vector2(0, heightIncrement);

            // Reset content position
            content.anchoredPosition = Vector2.zero;
        }

        private void ClearGrid()
        {
            if (m_GridElements == null || m_GridElements.Count == 0)
                return;

            foreach (var element in m_GridElements)
                Destroy(element);

            m_GridElements = new List<GameObject>();
        }
    }
}
