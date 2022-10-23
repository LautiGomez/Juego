using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderSequence: MonoBehaviour
{
    public GameObject fakeLadder;
    public GameObject realLadder;
    public GameObject examineHole;
    public GameObject placeSpot;
    

    void Update()
    {
        if (fakeLadder.activeSelf == false)
        {
            examineHole.SetActive(false);
            placeSpot.SetActive(true);
        }
    }
}
