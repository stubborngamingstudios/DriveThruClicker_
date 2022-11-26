using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NaughtyAttributes;

public class DebugBuyRateUIController : MonoBehaviour
{
    [ReadOnly] public DebugEconomyController debugEconomyController;

    TextMeshProUGUI myText;
    public string preLable = "$";

    public enum storeType { coffee, donut, burger }
    public storeType storeState;


    private void Awake()
    {
        debugEconomyController = FindObjectOfType<DebugEconomyController>();
        myText = GetComponentInChildren<TextMeshProUGUI>();
    }



    private void Update()
    {
        if (storeState == storeType.coffee) myText.text = preLable + debugEconomyController.perCoffeeAmount.ToString();
        if (storeState == storeType.donut) myText.text = preLable + debugEconomyController.perDonutAmount.ToString();
        if (storeState == storeType.burger) myText.text = preLable + debugEconomyController.perBurgerAmount.ToString();
    }


}
