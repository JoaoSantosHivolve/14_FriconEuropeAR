using System;
using UnityEngine;

namespace FridgeScripts
{
    [Serializable]
    public struct Fridge
    {
        public string name;
        public GameObject fridgeObject;
        public Sprite display;
        public Sprite[] images;
    }

    [Serializable]
    public struct FridgeColor
    {
        public string name;
        public Color squareColor;
        public Material material;
    }
}