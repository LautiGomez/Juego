using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StalkerIA : MonoBehaviour
{
    NavMeshAgent stalkerAgent;
    public GameObject stalkerEnemy;
    public GameObject stalkerPlayer;
    public GameObject stalkerOrigin;
    public float stalkerSpeed;
    public float returnSpeed;
    public static bool isStalking;
    public static bool stopStalking = false;
    public static bool readyToStalk = true;
    public string idle;
    public string walking;
    public string attacking;
    public static bool attackTrigger = false;
    public static bool isAttacking = false;
    public float animDuration;
    public int damageDone;
    // Start is called before the first frame update
    void Start()
    {
        stalkerAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(readyToStalk == true && isAttacking == false)
        {
            if (isStalking == false )
            {
                stalkerEnemy.GetComponent<Animator>().Play(idle);
            }
            else
            {
                stalkerAgent.speed = stalkerSpeed;
                stalkerEnemy.GetComponent<Animator>().Play(walking);
                stalkerAgent.SetDestination(stalkerPlayer.transform.position);
            }
        }
        if (stopStalking == true)
        {
            readyToStalk = false;
            stalkerEnemy.GetComponent<Animator>().Play(idle);
            stalkerAgent.SetDestination(stalkerOrigin.transform.position);
            stalkerAgent.speed = returnSpeed;
        }
        if (attackTrigger == true && isAttacking == false)
        {
            StartCoroutine(PlayerDamage.InflictDamage());
            StartCoroutine(StalkerAttack());
            GlobalHealth.currentHealth -= damageDone;
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

    IEnumerator StalkerAttack()
    {
        readyToStalk = false;
        isStalking = false;
        stalkerAgent.speed = 0;
        Debug.Log("se detiene");
        stalkerEnemy.GetComponent<Animator>().Play(attacking);
        yield return new WaitForSeconds(animDuration);
        readyToStalk = true;
        isStalking = true;
    }
}
