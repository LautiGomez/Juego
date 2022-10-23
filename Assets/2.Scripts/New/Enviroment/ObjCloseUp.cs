using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjCloseUp : MonoBehaviour
{
    PlayerMovement1 playerMovement1;
    [SerializeField] GameObject player;

    public float TheDistance;

    public GameObject theObj;
    public GameObject halfFade;
    public GameObject text;
    public GameObject uiObj;
    public GameObject objLight;
    public GameObject crossair;
    public string description;

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
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 2)
            {
                StartCoroutine(ObjCloseLook());
            }
        }
    }

    IEnumerator ObjCloseLook()
    {
        playerMovement1.disable = true;
        PlayerCam.disable = true;
        crossair.SetActive(false);
        halfFade.SetActive(true);
        objLight.SetActive(true);
        uiObj.SetActive(true);
        text.GetComponent<Text>().text = description;
        yield return new WaitForSeconds(4);
        halfFade.SetActive(false);
        uiObj.SetActive(false);
        objLight.SetActive(false);
        text.GetComponent<Text>().text = "";
        crossair.SetActive(true);
        playerMovement1.disable = false;
        PlayerCam.disable = false;
    }
}
