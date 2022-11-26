using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugPurchaseStats : MonoBehaviour
{
    public int coffee_count;
    public int donut_count;
    public int burger_count;


    public TextMeshProUGUI temp_Stats_Text;
    DebugEconomyController debugEconomyController;

    private void Start()
    {
        debugEconomyController = FindObjectOfType<DebugEconomyController>();
    }

    public void AddCoffeeCount()
    {
        coffee_count++;
        debugEconomyController.AddAmountToWallet(debugEconomyController.perCoffeeAmount);
    }
    public void AddDonutCount()
    {
        donut_count++;
        debugEconomyController.AddAmountToWallet(debugEconomyController.perDonutAmount);

    }
    public void AddBurgerCount()
    {
        burger_count++;
        debugEconomyController.AddAmountToWallet(debugEconomyController.perBurgerAmount);

    }




    private void Update()
    {
        temp_Stats_Text.text = "coffee_count: " + coffee_count + "  |  " +
                             "donut_count: " + donut_count + " | " +
                             "burger_coun: " + burger_count;
    }

}
