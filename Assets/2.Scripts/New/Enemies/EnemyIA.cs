using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public float enemySpeed = 0.005f;
    public bool attackTrigger = false;
    public bool isAttacking = false;
    int damageTaken = 25;
    public AudioSource hurtSound1;
    public AudioSource hurtSound2;
    public AudioSource hurtSound3;
    public int hurtGen;
    public GameObject hurtFlash;

    void Update()
    {
        transform.LookAt(player.transform);
        if(attackTrigger == false)
        {
            enemySpeed = 0.005f;
            enemy.GetComponent<Animation>().Play("Z_Walk1_InPlace");
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySpeed);
        }
        if (attackTrigger == true && isAttacking == false)
        {
            enemySpeed = 0;
            enemy.GetComponent<Animation>().Play("Z_Attack");
            StartCoroutine(InflictDamage());
        }
    }

    private void OnTriggerEnter()
    {
        attackTrigger = true;
    }

    private void OnTriggerExit()
    {
        attackTrigger = false;
    }
    
    IEnumerator InflictDamage()
    {
        isAttacking = true;
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
        GlobalHealth.currentHealth -= damageTaken;
        yield return new WaitForSeconds(0.2f);
        isAttacking = false;
    }
}
