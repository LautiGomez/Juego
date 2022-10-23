using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{

    PlayerMovement1 playerMovement1;
    [SerializeField] GameObject player;

    public float TheDistance;


    public GameObject healthPack;
    public GameObject extraCross;
    
    public AudioSource healthPicked;




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
                PickUp();
            }
        }

    }
    private void OnMouseExit()
    {
        extraCross.SetActive(false);
    }

    void PickUp()
    {
        healthPicked.Play();
        extraCross.SetActive(false);
        GlobalInventory.currentAmountHealthPacks += 1;
        healthPack.SetActive(false);
    }
}
