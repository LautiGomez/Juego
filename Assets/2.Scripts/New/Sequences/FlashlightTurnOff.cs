using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightTurnOff : MonoBehaviour
{
    public GameObject flashlightLight;

    private void OnTriggerEnter(Collider other)
    {
        flashlightLight.SetActive(false);
         this.GetComponent<BoxCollider>().enabled = false;
    }
}
