using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUiActive : MonoBehaviour
{
    public GameObject glock;
    public GameObject shotgun;

    public GameObject shotgunUI;
    public GameObject glockUI;

    // Update is called once per frame
    void Update()
    {
        if (glock.activeSelf)
        {
            glockUI.SetActive(true);
        }
        else
        {
            glockUI.SetActive(false);
        }

        if (shotgun.activeSelf)
        {
            shotgunUI.SetActive(true);
        }
        else
        {
            shotgunUI.SetActive(false);
        }
    }
}
