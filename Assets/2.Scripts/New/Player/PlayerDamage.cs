using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{

    public GameObject player;
    //public static int damageTaken;
    public static AudioSource hurtSound1;
    public static AudioSource hurtSound2;
    public static AudioSource hurtSound3;
    public static int hurtGen;
    public static GameObject hurtFlash;
    //public int setDamageTaken = 25;
    public AudioSource setHurtSound1;
    public AudioSource setHurtSound2;
    public AudioSource setHurtSound3;
    public int setHurtGen;
    public GameObject setHurtFlash;

    private void Awake()
    {
        //damageTaken = setDamageTaken;
        hurtSound1 = setHurtSound1;
        hurtSound2 = setHurtSound2;
        hurtSound3 = setHurtSound3;
        hurtGen = setHurtGen;
        hurtFlash = setHurtFlash;
    }


    /*
    void Update()
    {
        if (StalkerIA.attackTrigger == true && StalkerIA.isAttacking == false)
        {
            StartCoroutine(InflictDamage());
            
        }
    }
    */
    public static IEnumerator InflictDamage()
    {
        Debug.Log("termina empieza");
        StalkerIA.isAttacking = true;
        hurtGen = Random.Range(1, 4);
        if (hurtGen == 1)
        {
            hurtSound1.Play();
        }
        if (hurtGen == 2)
        {
            hurtSound2.Play();
        }
        if (hurtGen == 3)
        {
            hurtSound3.Play();
        }
        hurtFlash.SetActive(true);
        yield return new WaitForSeconds(0.13f);
        hurtFlash.SetActive(false);
        yield return new WaitForSeconds(1.1f);
        //GlobalHealth.currentHealth -= damageTaken;
        yield return new WaitForSeconds(0.2f);
        StalkerIA.isAttacking = false;
        Debug.Log("termina corrutina");
    }
}
