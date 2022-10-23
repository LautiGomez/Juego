using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipWeapons : MonoBehaviour
{
    public Transform holster;

    public GameObject pipe;
    public GameObject glock;
    public GameObject shotgun;

    private void Update()
    {
        if (PickUpShotgun.wasPickedUp == true)
        {
            shotgun.transform.SetParent(this.transform);
        }
        if (PickUpGlock.wasPickedUp == true)
        {
            glock.transform.SetParent(this.transform);
        }
        if (PickUpPipe.wasPickedUp == true)
        {
            pipe.transform.SetParent(this.transform);
        }
    }
}
