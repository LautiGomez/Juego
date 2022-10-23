using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLadder : MonoBehaviour
{
    PlayerMovement1 playerMovement1;
    [SerializeField] GameObject player;

    public float TheDistance;

    public GameObject fakeLadder;

    public AudioSource PickUpSound;
    public GameObject extraCross;
    public static bool wasPickedUp = false;



    private void Start()
    {
        playerMovement1 = player.GetComponent<PlayerMovement1>();
    }

    // Update is called once per frame
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 2)
        {
            extraCross.SetActive(true);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 2)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                fakeLadder.GetComponent<MeshRenderer>().enabled = false;
                PickUpSound.Play();
                extraCross.SetActive(false);
                StartCoroutine(Wait());
            }
        }

    }
    private void OnMouseExit()
    {
        extraCross.SetActive(false);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4.01f);
        fakeLadder.SetActive(false);
        wasPickedUp = true;
    }
}
