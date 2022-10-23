using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAmmo : MonoBehaviour
{
    public GameObject glockammoDisplay;
    public GameObject glockloadedDisplay;
    public static int glockammoCurrent;
    public static int glockloadedAmmo;
    public int glockinternalAmmo;
    public int glockinternalLoadedAmmo;

    public GameObject shotgunammoDisplay;
    public GameObject shotgunloadedDisplay;
    public static int shotgunammoCurrent;
    public static int shotgunloadedAmmo;
    public int shotguninternalAmmo;
    public int shotguninternalLoadedAmmo;

    void Update()
    {
        glockinternalAmmo = glockammoCurrent;
        glockinternalLoadedAmmo = glockloadedAmmo;
        glockammoDisplay.GetComponent<Text>().text = "" + glockinternalAmmo;
        glockloadedDisplay.GetComponent<Text>().text = "" + glockloadedAmmo;

        shotguninternalAmmo = shotgunammoCurrent;
        shotguninternalLoadedAmmo = shotgunloadedAmmo;
        shotgunammoDisplay.GetComponent<Text>().text = "" + shotguninternalAmmo;
        shotgunloadedDisplay.GetComponent<Text>().text = "" + shotgunloadedAmmo;
    }
}
