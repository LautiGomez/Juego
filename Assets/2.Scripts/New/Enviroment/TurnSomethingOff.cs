using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSomethingOff : MonoBehaviour
{
    public GameObject[] objsToDeactivate;

    public GameObject thisTrigger;

    private void OnTriggerEnter(Collider other)
    {
        TurnOff();
        thisTrigger.SetActive(false);
    }

    void TurnOff()
    {
        for (int i = 0; i < objsToDeactivate.Length; i++)
        {
            objsToDeactivate[i].SetActive(false);
        }
    }
   
}
