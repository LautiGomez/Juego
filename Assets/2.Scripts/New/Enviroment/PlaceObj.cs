using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObj : MonoBehaviour
{
    PlayerMovement1 playerMovement1;
    [SerializeField] GameObject player;

    public float TheDistance;

    public GameObject placeSpot;
    public GameObject fakeObj;
    public GameObject realObj;
    public AudioSource placeSound;
    
    public GameObject extraCross;
    public Animation doorFade;
    public bool isPressed = false;
    public static bool wasPlaced = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
            if (TheDistance <= 2 && isPressed == false)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                PlaceObject();
                wasPlaced = true;
                placeSpot.SetActive(false);
            }
        }
    }
    private void OnMouseExit()
    {
        extraCross.SetActive(false);
    }

    void PlaceObject()
    {
        if(fakeObj.activeSelf == false)
        {
            realObj.SetActive(true);
            placeSound.Play();
        }
    }
}
