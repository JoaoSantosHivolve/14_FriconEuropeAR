using System.Collections;
using System.Collections.Generic;
using Languages.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Grids
{
    public class PopulateDetailsGrid : MonoBehaviour
    {
        [Header("Grid Elements")]
        public GameObject prefab;
        public RectTransform scrollView;
        public RectTransform content;

        public Color background1;
        public Color background2;

        private List<GameObject> m_GridElements = new List<GameObject>();
        private GameObject[,] m_Grid;

        private float m_Width;

        public void Populate(string fridgeName)
        {
            ClearGrid();

            // Get fridge
            var fridge = XmlLoader.Instance.GetFridge(fridgeName);
            m_Width = scrollView.rect.width / fridge.columnsCount;

            // Init Grid
            m_Grid = new GameObject[fridge.rowsCount,fridge.columnsCount];

            for (var r = 0; r < fridge.rowsCount; r++)
            {
                for (var c = 0; c < fridge.columnsCount; c++)
                {
                    // Instantiate prefab
                    var newElement = Instantiate(prefab, transform);

                    // Set prefab text alignment
                    newElement.GetComponent<TextMeshProUGUI>().alignment = c == 0 ? TextAlignmentOptions.Left : TextAlignmentOptions.Center;

                    // Set prefab background color
                    newElement.transform.GetChild(0).GetComponent<Image>().color = r % 2 == 0 ? background2 : background1;

                    // Change prefab text
                    newElement.GetComponent<TextMeshProUGUI>().text = fridge.rows[r].element[c].text;

                    // Set prefab width
                    var sd = newElement.GetComponent<RectTransform>().sizeDelta;
                    newElement.GetComponent<RectTransform>().sizeDelta = new Vector2(m_Width, sd.y);

                    // Add prefab to list
                    m_GridElements.Add(newElement);

                    // Save element in dual array
                    m_Grid[r, c] = newElement;
                }
            }
        }
        private void OnEnable()
        {
            StartCoroutine(SetGridElementsPosition());
        }

        private IEnumerator SetGridElementsPosition()
        {
            yield return new WaitForEndOfFrame();

            if (m_Grid == null)
                Debug.Log("m_Grid is fucked");

            var yPos = 0.0f;

            for (var r = 0; r < m_Grid.GetLength(0); r++)
            {
                // Search for element on row with biggest height
                var height = GetBiggestHeight(r);

                for (var c = 0; c < m_Grid.GetLength(1); c++)
                {
                    // Remove size fitter
                    m_Grid[r, c].GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.Unconstrained;

                    // Set prefab width
                    m_Grid[r,c].GetComponent<RectTransform>().sizeDelta = new Vector2(m_Width, height);

                    // Set prefab position
                    m_Grid[r,c].GetComponent<RectTransform>().anchoredPosition = new Vector2(m_Width * c, -yPos);
                }

                // Increment height
                yPos += height;
            }

            // Set content size
            content.sizeDelta = new Vector2(0, yPos);

            // Reset content position
            content.anchoredPosition = Vector2.zero;
        }

        private float GetBiggestHeight(int row)
        {
            var height = m_Grid[row, 0].GetComponent<RectTransform>().sizeDelta.y;

            for (var i = 1; i < m_Grid.GetLength(1); i++)
            {
                if (m_Grid[row, i].GetComponent<RectTransform>().sizeDelta.y > height)
                    height = m_Grid[row, i].GetComponent<RectTransform>().sizeDelta.y;
            }

            return height;
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
