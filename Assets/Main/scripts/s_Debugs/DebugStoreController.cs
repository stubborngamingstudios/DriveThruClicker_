using KamaliDebug;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugStoreController : MonoBehaviour
{

    public List<GameObject> myStores = new List<GameObject>();


    public int activeStoreIndex = -1;

    public bool maxStoreInLaneActive = false;

    [Button]
    private void resetAllStores()
    {
        activeStoreIndex = -1;

        for (int i = 0; i < myStores.Count; i++)
        {
            myStores[i].SetActive(false);

        }
        CheckAllStoresActive();
    }


    [Button]
    public void IncrementStoreActivation()
    {
        if (activeStoreIndex != myStores.Count - 1)
        {
            activeStoreIndex++;
        }


        if (activeStoreIndex < myStores.Count)
        {
            myStores[activeStoreIndex].SetActive(true);
            CheckAllStoresActive();
        }

    }



    private void CheckAllStoresActive()
    {

        for (int i = 0; i < myStores.Count; i++)
        {

            if (myStores[i].activeSelf)
            {
                maxStoreInLaneActive = true;

            }
            else
            {
                maxStoreInLaneActive = false;

            }

        }
    }

}
