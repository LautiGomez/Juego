using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShotgun : MonoBehaviour
{
    public GameObject shotgun;
    public GameObject muzzleFlash;
    public AudioSource shotgunShot;
    public AudioSource emptyShot;
    public static bool isFiring = false;
    public int DamageAmount = 10;
    public float targetDistance;
    public string shotgunShotAnim;
    public int range;

    private void Awake()
    {
        //DamageAmount = Random.Range(3, 7);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ReloadShotgun.isReloading == false)
        {
            if (isFiring == false && GlobalAmmo.shotgunloadedAmmo >= 1)
            {
                GlobalAmmo.shotgunloadedAmmo -= 1;
                StartCoroutine(FiringShotgun());
            }
            if (isFiring == false && GlobalAmmo.shotgunloadedAmmo == 0)
            {
                StartCoroutine(EmptyFireShotgun());
            }
        }
        
    }
    IEnumerator FiringShotgun()
    {
        RaycastHit shot;
        isFiring = true;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot, range))
        {
            print(shot.transform.name);
            targetDistance = shot.distance;
            shot.transform.SendMessage("DamageEnemy",DamageAmount, SendMessageOptions.DontRequireReceiver);
        }
        shotgun.GetComponent<Animation>().Play(shotgunShotAnim);
        muzzleFlash.SetActive(true);
        shotgunShot.Play();
        yield return new WaitForSeconds(1.2f);
        muzzleFlash.SetActive(false);
        isFiring = false;
    }

    IEnumerator EmptyFireShotgun()
    {
        isFiring = true;
        emptyShot.Play();
        yield return new WaitForSeconds(1);
        isFiring = false;
    }
}
