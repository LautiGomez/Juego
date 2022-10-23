using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPipe : MonoBehaviour
{
    public GameObject pipe;
    public AudioSource swingSound;
    public static bool isAttacking = false;
    public int DamageAmount = 10;
    public float targetDistance;
    public string pipeAttack;
    public float range;

    private void Awake()
    {
        //DamageAmount = Random.Range(3, 7);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isAttacking == false)
        {
           StartCoroutine(AttakingPipe());
        }
        
    }
    IEnumerator AttakingPipe()
    {
        RaycastHit shot;
        isAttacking = true;
        pipe.GetComponent<Animation>().Play(pipeAttack);
        yield return new WaitForSeconds(0.50f);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot, range))
        {
            print(shot.transform.name);
            targetDistance = shot.distance;
            shot.transform.SendMessage("DamageEnemy",DamageAmount, SendMessageOptions.DontRequireReceiver);
        }
        swingSound.Play();
        yield return new WaitForSeconds(0.72f);
        isAttacking = false;
    }
}
