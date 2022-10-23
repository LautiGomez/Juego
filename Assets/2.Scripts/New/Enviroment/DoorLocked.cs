using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorLocked : MonoBehaviour
{
    PlayerMovement1 playerMovement1;
    [SerializeField] GameObject player;

    public float TheDistance;

    public GameObject extraCross;
    public AudioSource lockedSound;
    public bool isPressed = false;

    public GameObject examineText;
    public GameObject backText;
    public string doorDescription;
    public float waitTime;
    //public GameObject key;




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
            if (TheDistance <=2 && isPressed == false)
            {
                extraCross.SetActive(false);
                StartCoroutine(DoorReset());
            }
        }
       
    }
    private void OnMouseExit()
    {
        extraCross.SetActive(false);
    }

    IEnumerator DoorReset()
    {
        playerMovement1.disable = true;
        PlayerCam.disable = true;
        isPressed = true;
        lockedSound.Play();
        backText.SetActive(true);
        examineText.GetComponent<Text>().text = doorDescription;
        yield return new WaitForSeconds(waitTime);
        examineText.GetComponent<Text>().text = "";
        backText.SetActive(false);
        isPressed = false;
        playerMovement1.disable = false;
        PlayerCam.disable = false;
    }

}
