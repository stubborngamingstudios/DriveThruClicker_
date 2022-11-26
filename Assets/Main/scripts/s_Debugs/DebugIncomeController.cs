using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugIncomeController : MonoBehaviour
{



    public List<DebugStoreController> myStores = new List<DebugStoreController>();
    [ReadOnly] public bool maxStoreInMyLanePurchased;



    private void Update()
    {


        for (int i = 0; i < myStores.Count; i++)
        {
            if (myStores[i].maxStoreInLaneActive)
            {
                //max store purchased!
                maxStoreInMyLanePurchased = true;

            }
            else
            {
                maxStoreInMyLanePurchased = false;

            }
        }
    }





}
