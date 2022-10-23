using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpPipe : MonoBehaviour
{
    PlayerMovement1 playerMovement1;
    [SerializeField] GameObject player;

    public float TheDistance;
    public GameObject fakePipe;
    public GameObject realPipe;
    public AudioSource pickUpSound;
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
            if (TheDistance <=2)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                pickUpSound.Play();
                fakePipe.SetActive(false);
                realPipe.SetActive(true);
                extraCross.SetActive(false);
                wasPickedUp = true;
            }
        }
       
    }
    private void OnMouseExit()
    {
        extraCross.SetActive(false);
    }


    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    //codigo de agus
    //Vector3 coordenadas;
    //[SerializeField] GameObject objeto;

    //void almacenarPosicion()
    //{
    //    coordenadas = objeto.transform.position;
    //}


}
