using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPickUp : MonoBehaviour
{
    PlayerMovement1 playerMovement1;
    [SerializeField] GameObject player;

    public float TheDistance;
    public GameObject extraCross;
    public GameObject theKey;
    public AudioSource PickUpSound;
    public GameObject[] opendDoors;
    public GameObject[] lockedDoors;



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
                extraCross.SetActive(false);
                theKey.GetComponent<MeshRenderer>().enabled = false;
                DoorUnlocking();
                PickUpSound.Play();
                StartCoroutine(Wait());
            }
        }

    }
    private void OnMouseExit()
    {
        extraCross.SetActive(false);
    }
    
    void DoorUnlocking()
    {
        
        for (int i = 0; i < lockedDoors.Length; i++) 
        {
            lockedDoors[i].SetActive(false);
        }
        for (int i = 0; i < opendDoors.Length; i++)
        {
            opendDoors[i].SetActive(true);
        }

    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4.01f);
        theKey.SetActive(false);
    }
}
