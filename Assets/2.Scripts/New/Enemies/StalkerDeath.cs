using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StalkerDeath : MonoBehaviour
{
    public static int EnemyHealth = 20;
    public GameObject stalkerEnemy;
    public int statusCheck;
    //public AudioSource enemyMusic;
    public AudioSource deathSound;
    public string death;

    void DamageEnemy(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
    }
    // Update is called once per frame
    void Update()
    {
        if (EnemyHealth <= 0 && statusCheck == 0)
        {
            this.GetComponent<StalkerIA>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            statusCheck = 2;
            deathSound.Play();
            stalkerEnemy.GetComponent<Animator>().Play(death);

            //enemyMusic.Stop();
        }
    }
}
