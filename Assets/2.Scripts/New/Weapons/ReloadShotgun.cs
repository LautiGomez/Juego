using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadShotgun : MonoBehaviour
{
    public AudioSource reloadSound;
    public AudioSource emptyReload;
    public GameObject shotgun;
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
        clipCount = GlobalAmmo.shotgunloadedAmmo;
        reserveCount = GlobalAmmo.shotgunammoCurrent;
       
        if (reserveCount == 0)
        {
            reloadAvailable = 0;
        }
        else
        {
            reloadAvailable = 2 - clipCount;
        }
        if (Input.GetButtonDown("Reload") && isReloading == false && FireShotgun.isFiring == false)
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


    /*
    IEnumerator ActionReload1()
    {
        isReloading = true;
        canon.GetComponent<FireGlock>().enabled = false;
        reloadSound.Play();
        glock.GetComponent<Animation>().Play(reload);
        yield return new WaitForSeconds(3.09f);
        GlobalAmmo.glockloadedAmmo += reserveCount;
        GlobalAmmo.glockammoCurrent -= reserveCount;
        canon.GetComponent<FireGlock>().enabled = true;
        isReloading = false;

    }
    */

    
    IEnumerator ActionReload1() //con funcionalidad de tactical y empty reload
    {
        isReloading = true;
        canon.GetComponent<FireShotgun>().enabled = false;
        if (clipCount == 0)
        {
            emptyReload.Play();
            shotgun.GetComponent<Animation>().Play(emptyReloadAnim);
            yield return new WaitForSeconds(7);
            GlobalAmmo.shotgunloadedAmmo += reserveCount;
            GlobalAmmo.shotgunammoCurrent -= reserveCount;
        }
        else
        {
            reloadSound.Play();
            shotgun.GetComponent<Animation>().Play(reload);
            yield return new WaitForSeconds(4.60f);
            GlobalAmmo.shotgunloadedAmmo += reserveCount;
            GlobalAmmo.shotgunammoCurrent -= reserveCount;
        }
        canon.GetComponent<FireShotgun>().enabled = true;
        isReloading = false;
    }
    

    /*
    IEnumerator ActionReload2()
    {
        isReloading = true;
        canon.GetComponent<FireGlock>().enabled = false;
        reloadSound.Play();
        glock.GetComponent<Animation>().Play(reload);
        yield return new WaitForSeconds(3.09f);
        GlobalAmmo.glockloadedAmmo += reloadAvailable;
        GlobalAmmo.glockammoCurrent -= reloadAvailable;
        canon.GetComponent<FireGlock>().enabled = true;
        isReloading = false;
    }
    */

    IEnumerator ActionReload2() //con funcionalidad de tactical y empty reload
    {
        isReloading = true;
        canon.GetComponent<FireShotgun>().enabled = false;
        if (clipCount == 0)
        {
            emptyReload.Play();
            shotgun.GetComponent<Animation>().Play(emptyReloadAnim);
            yield return new WaitForSeconds(7);
            GlobalAmmo.shotgunloadedAmmo += reloadAvailable;
            GlobalAmmo.shotgunammoCurrent -= reloadAvailable;
        }
        else
        {
            reloadSound.Play();
            shotgun.GetComponent<Animation>().Play(reload);
            yield return new WaitForSeconds(4.60f);
            GlobalAmmo.shotgunloadedAmmo += reloadAvailable;
            GlobalAmmo.shotgunammoCurrent -= reloadAvailable;
        }
        canon.GetComponent<FireShotgun>().enabled = true;
        isReloading = false;
    }
    
}
