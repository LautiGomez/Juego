using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalInventory : MonoBehaviour
{
    public static bool key2 = false;
    public string puzzleObjName;

    public static int currentAmountHealthPacks;
    public int internalHealthPacks;
    public GameObject healthPackDisplay;
    public GameObject healthUI;


    private void Start()
    {

    }
    void Update()
    {
        HealthSystem();
    }

    void HealthSystem()
    {
        internalHealthPacks = currentAmountHealthPacks;
        healthPackDisplay.GetComponent<Text>().text = "" + internalHealthPacks;

        if (internalHealthPacks == 0)
        {
            healthUI.SetActive(false);
        }
        else
        {
            healthUI.SetActive(true);
        }
    }
}
