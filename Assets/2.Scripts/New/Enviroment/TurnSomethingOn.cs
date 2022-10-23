using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSomethingOn : MonoBehaviour
{
    public GameObject[] objsToActivate;

    public GameObject thisTrigger;

    private void OnTriggerEnter(Collider other)
    {
        TurnOn();
        thisTrigger.SetActive(false);
    }

    void TurnOn()
    {
        for (int i = 0; i < objsToActivate.Length; i++)
        {
            objsToActivate[i].SetActive(true);
        }
    }
}
