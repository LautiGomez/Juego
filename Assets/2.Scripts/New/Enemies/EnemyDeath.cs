
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public int EnemyHealth = 20;
    public GameObject enemy;
    public int statusCheck;
    //public AudioSource enemyMusic;    
    public string idle;
    public string death;
    void DamageEnemy (int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
    }
    // Update is called once per frame
    void Update()
    {
        if (EnemyHealth <= 0 && statusCheck == 0)
        {
            this.GetComponent<EnemyIA>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            statusCheck = 2;
            enemy.GetComponent<Animation>().Stop(idle);
            enemy.GetComponent<Animation>().Play(death);
            //enemyMusic.Stop();
        }
    }
}
