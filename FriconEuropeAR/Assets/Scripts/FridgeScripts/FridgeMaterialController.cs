using System.Collections.Generic;
using UnityEngine;

namespace FridgeScripts
{
    public class FridgeMaterialController : MonoBehaviour
    {
        public List<MeshRenderer> renderers;
        public int selectedColor;

        public void SetMaterial(Material mat, int colorNum)
        {
            selectedColor = colorNum;

            for (var i = 0; i < renderers.Count; i++)
            {
                var mats = new Material[renderers[i].materials.Length];
                for (var j = 0; j < mats.Length; j++)
                {
                    mats[j] = mat;
                }

                renderers[i].materials = mats;
            }
        }
    }
}