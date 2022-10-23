using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerIATriggerOn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //this.gameObject.GetComponent<BoxCollider>().enabled = false;
        StalkerIA.readyToStalk = true;
        StalkerIA.isStalking = true;
        StalkerIA.stopStalking = false;
    }
}
