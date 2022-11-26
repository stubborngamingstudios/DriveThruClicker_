using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button AddCar_Button;
    public TextMeshProUGUI addCarCost_Text;

    public Button AddRoad_Button;
    public TextMeshProUGUI addRoadCost_Text;

    public Button MergeCar_Button;
    public TextMeshProUGUI mergeCarCost_Text;

    public Button Income_Button;
    public TextMeshProUGUI incomeCost_Text;

    public TextMeshProUGUI Wallet_Text;

    public string myWallet_Lable = "$ ";





    public void DisplayWallettUI(float walletCounter)
    {
        Wallet_Text.text = myWallet_Lable + walletCounter.ToString();

    }





    public void DisplayCarCostUI(float buyRate)
    {
        addCarCost_Text.text = myWallet_Lable + buyRate.ToString();

    }
    public void DisplayRoadCostUI(float roadBuyRate)
    {
        addRoadCost_Text.text = myWallet_Lable + roadBuyRate.ToString();

    }
    public void DisplayMergeCostUI(float mergeRate)
    {
        mergeCarCost_Text.text = myWallet_Lable + mergeRate.ToString();

    }
    public void DisplayIncomeCostUI(float incomeRate)
    {
        incomeCost_Text.text = myWallet_Lable + incomeRate.ToString();

    }






    public void EnableOrDisableTargetButton(Button targetButton, bool activeState)
    {
        targetButton.interactable = activeState;
    }
}
