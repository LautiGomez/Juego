using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{
    public bool isOn = false;
    public GameObject lightSourse;
    public bool failSafe = false;
    public GameObject text;
    public GameObject backText;
    public string noBaterries;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && FlashlightPickUp.wasPickedUp == true && FlashlightPickUpBattery.wasPickedUp == false)
        {
            StartCoroutine(NoBatteries());
        }
        if (Input.GetKeyDown(KeyCode.F) && FlashlightPickUp.wasPickedUp == true && FlashlightPickUpBattery.wasPickedUp == true)
        {
            if (isOn == false && failSafe == false)
            {
                failSafe = true;
                lightSourse.SetActive(true);
                isOn = true;
                StartCoroutine(FailSafe());
            }
            if (isOn == true && failSafe == false)
            {
                failSafe = true;
                lightSourse.SetActive(false);
                isOn = false;
                StartCoroutine(FailSafe());
            }
        }

    }
    IEnumerator FailSafe()
    {
        yield return new WaitForSeconds(0.25f);
        failSafe = false;
    }

    IEnumerator NoBatteries()
    {
        backText.SetActive(true);
        text.GetComponent<Text>().text = noBaterries;
        yield return new WaitForSeconds(3);
        text.GetComponent<Text>().text = "";
        backText.SetActive(false);
        //isExamining = false;
    }
}
