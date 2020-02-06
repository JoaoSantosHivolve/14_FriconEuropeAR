using System.Collections.Generic;
using FridgeScripts;
using GoogleARCore.Examples.ObjectManipulation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManipulationHudController : MonoBehaviour
{
    [Header("UI Elements")]
    public List<Button> buttons;
    public Button confirmButton;
    public TextMeshProUGUI hudomFridgeName;
    [Header("UI Animators")]
    public Animator hudomAnimator;
    [Header("Object manipulation system")]
    public ManipulationSystem manipulationSystem;

    private static readonly int Activated = Animator.StringToHash("activated");

    private void Awake()
    {
        confirmButton.onClick.AddListener(manipulationSystem.Deselect);
    }
    private void Start()
    {
        for (var i = 0; i < FridgeMaterialsManager.Instance.fridgeColors.Count; i++)
        {
            buttons[i].image.color = FridgeMaterialsManager.Instance.fridgeColors[i].squareColor;
        }
    }
    private void Update()
    {
        // Detect object change
        if (manipulationSystem.SelectedObject == null)
        {
            hudomAnimator.SetBool(Activated, false);
            hudomFridgeName.text = "";
        }
        else
        {
            hudomAnimator.SetBool(Activated, true);
            hudomFridgeName.text = manipulationSystem.SelectedObject.GetComponent<Manipulator>().fridge.name;
        }
    }

  

    public void ChangeMaterial_OnClick(int num)
    {
        var material = FridgeMaterialsManager.Instance.GetMaterial(num);
        manipulationSystem.SelectedObject.GetComponent<Manipulator>().materialController.SetMaterial(material, num);
    }
}
