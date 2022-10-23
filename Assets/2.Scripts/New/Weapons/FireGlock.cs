using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGlock : MonoBehaviour
{
    public GameObject glock;
    public GameObject muzzleFlash;
    public AudioSource gunShot;
    public AudioSource emptyShot;
    public static bool isFiring = false;
    public int DamageAmount = 5;
    public float targetDistance;
    public AudioSource enemyHurt;

    private void Awake()
    {
        //DamageAmount = Random.Range(3, 7);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ReloadGlock.isReloading == false)
        {
            if (isFiring == false && GlobalAmmo.glockloadedAmmo >= 1)
            {
                GlobalAmmo.glockloadedAmmo -= 1;
                StartCoroutine(FiringGlock());
            }
            if (isFiring == false && GlobalAmmo.glockloadedAmmo == 0)
            {
                StartCoroutine(EmptyFireGlock());
            }
        }
        
    }
    IEnumerator FiringGlock()
    {
        RaycastHit shot;
        isFiring = true;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
        {
            print(shot.transform.name);
            targetDistance = shot.distance;
            shot.transform.SendMessage("DamageEnemy",DamageAmount, SendMessageOptions.DontRequireReceiver);
            if (StalkerDeath.EnemyHealth >= 5)
            {
            enemyHurt.Play();
            }
        }
        glock.GetComponent<Animation>().Play("FullGlockShot");
        muzzleFlash.SetActive(true);
        gunShot.Play();
        yield return new WaitForSeconds(0.8f);
        muzzleFlash.SetActive(false);
        isFiring = false;
    }

    IEnumerator EmptyFireGlock()
    {
        isFiring = true;
        emptyShot.Play();
        yield return new WaitForSeconds(0.8f);
        isFiring = false;
    }
}
