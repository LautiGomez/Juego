using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlighStair : MonoBehaviour
{
    PlayerMovement1 playerMovement1;
    [SerializeField] GameObject player;

    public float TheDistance;

    public GameObject extraCross;
    public bool isPressed = false;

    public Transform TeleportDest;
    public Animation doorFade;
    public AudioSource goingUpSound;

    public GameObject examineText;
    public GameObject backText;
    public string doorDescription;
    public float waitTime;




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
            if (TheDistance <= 2 && isPressed == false && FlashlightPickUp.wasPickedUp == !true || FlashlightPickUpBattery.wasPickedUp == !true)
            {
                extraCross.SetActive(false);
                StartCoroutine(TooDark());
            }
            if (TheDistance <= 2 && isPressed == false && FlashlightPickUp.wasPickedUp == true && FlashlightPickUpBattery.wasPickedUp == true)
            {
                StartCoroutine(Teleport());
            }
        }

    }
    private void OnMouseExit()
    {
        extraCross.SetActive(false);
    }

    IEnumerator TooDark()
    {
        playerMovement1.disable = true;
        PlayerCam.disable = true;
        isPressed = true;
        backText.SetActive(true);
        examineText.GetComponent<Text>().text = doorDescription;
        yield return new WaitForSeconds(waitTime);
        examineText.GetComponent<Text>().text = "";
        backText.SetActive(false);
        isPressed = false;
        playerMovement1.disable = false;
        PlayerCam.disable = false;
    }

    IEnumerator Teleport()
    {
        goingUpSound.Play();
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
