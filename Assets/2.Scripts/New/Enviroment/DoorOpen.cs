using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorOpen : MonoBehaviour
{
    PlayerMovement1 playerMovement1;
    [SerializeField] GameObject player;

    public float TheDistance;
    
    
    public GameObject Door;
    public AudioSource doorSound;
    public Transform TeleportDest;
    public GameObject extraCross;
    public Animation doorFade;
    public bool isPressed = false;


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
            if (TheDistance <=2 && isPressed ==false)
            {
                StartCoroutine(Teleport());
            }
        }
       
    }
    private void OnMouseExit()
    {
        extraCross.SetActive(false);
    }

    IEnumerator Teleport()
    {
        doorSound.Play();
        playerMovement1.disable = true;
        PlayerCam.disable = true;
        isPressed = true;
        doorFade.Play("DoorFade");
        yield return new WaitForSeconds(1f);
        player.transform.position = TeleportDest.position;
        yield return new WaitForSeconds(1f);
        isPressed = false;
        playerMovement1.disable = false;
        PlayerCam.disable = false;
    }
}
