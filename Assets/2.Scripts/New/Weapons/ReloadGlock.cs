using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadGlock : MonoBehaviour
{
    public AudioSource reloadSound;
    public AudioSource emptyReload;
    public GameObject glock;
    public GameObject canon;
    public int clipCount;
    public int reserveCount;
    public int reloadAvailable;
    public string reload;
    public string emptyReloadAnim;
    public static bool isReloading = false;

    private void Awake()
    {

    }

    void Update()
    {
        clipCount = GlobalAmmo.glockloadedAmmo;
        reserveCount = GlobalAmmo.glockammoCurrent;
       
        if (reserveCount == 0)
        {
            reloadAvailable = 0;
        }
        else
        {
            reloadAvailable = 12 - clipCount;
        }
        if (Input.GetButtonDown("Reload") && isReloading == false && FireGlock.isFiring == false)
        {
            if (reloadAvailable >= 1)
            {
                if(reserveCount <= reloadAvailable)
                {
                    StartCoroutine(ActionReload1());
                }
                else
                {
                    StartCoroutine(ActionReload2());
                }
            }
        }
    }
    
    IEnumerator ActionReload1() //con funcionalidad de tactical y empty reload
    {
        isReloading = true;
        canon.GetComponent<FireGlock>().enabled = false;
        if (clipCount == 0)
        {
            reloadSound.Play();
            glock.GetComponent<Animation>().Play(reload);
            yield return new WaitForSeconds(3.3f);
            GlobalAmmo.glockloadedAmmo += reserveCount;
            GlobalAmmo.glockammoCurrent -= reserveCount;
        }
        else
        {
            emptyReload.Play();
            glock.GetComponent<Animation>().Play(emptyReloadAnim);
            yield return new WaitForSeconds(2.3f);
            GlobalAmmo.glockloadedAmmo += reserveCount;
            GlobalAmmo.glockammoCurrent -= reserveCount;
        }
        canon.GetComponent<FireGlock>().enabled = true;
        isReloading = false;
    }
    
    IEnumerator ActionReload2() //con funcionalidad de tactical y empty reload
    {
        isReloading = true;
        canon.GetComponent<FireGlock>().enabled = false;
        if (clipCount == 0)
        {
            reloadSound.Play();
            glock.GetComponent<Animation>().Play(reload);
            yield return new WaitForSeconds(3.3f);
            GlobalAmmo.glockloadedAmmo += reloadAvailable;
            GlobalAmmo.glockammoCurrent -= reloadAvailable;
        }
        else
        {
            emptyReload.Play();
            glock.GetComponent<Animation>().Play(emptyReloadAnim);
            yield return new WaitForSeconds(2.3f);
            GlobalAmmo.glockloadedAmmo += reloadAvailable;
            GlobalAmmo.glockammoCurrent -= reloadAvailable;
        }
        canon.GetComponent<FireGlock>().enabled = true;
        isReloading = false;
    }
    
}
