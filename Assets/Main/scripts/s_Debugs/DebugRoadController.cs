using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugRoadController : MonoBehaviour
{
    public List<GameObject> myRoads = new List<GameObject>();
    public List<DebugStoreController> myRoadsStores = new List<DebugStoreController>();


    public int activeRoadIndex = 0;
    public bool allRoadActive = false;








    [Button]
    private void ResetAllRoads()
    {
        activeRoadIndex = 0;
        for (int i = 1; i < myRoads.Count; i++)
        {
            myRoads[i].SetActive(false);

        }
        CheckAllActiveRoad();


    }


    [Button]
    public void IncrementRoadActivation()
    {
        if (activeRoadIndex != myRoads.Count - 1)
        {
            activeRoadIndex++;
        }


        if (activeRoadIndex < myRoads.Count)
        {
            myRoads[activeRoadIndex].SetActive(true);



            CheckAllActiveRoad();
        }

    }

    private void CheckAllActiveRoad()
    {

        for (int i = 0; i < myRoads.Count; i++)
        {

            if (myRoads[i].activeSelf)
            {
                allRoadActive = true;

            }
            else
            {
                allRoadActive = false;

            }

        }
    }



    public void IncrementStoreActivation(DebugStoreController targetStore)
    {
        targetStore.IncrementStoreActivation();

    }

}
