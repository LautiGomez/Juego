using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StalkerIATriggerOff : MonoBehaviour
{
 

    private void OnTriggerEnter(Collider other)
    {
        //this.gameObject.GetComponent<BoxCollider>().enabled = false;
        StalkerIA.isStalking = false;
        StalkerIA.readyToStalk = false;
        StalkerIA.stopStalking = true;
    }
}
