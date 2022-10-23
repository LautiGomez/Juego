using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpAmmoShotgun : MonoBehaviour
{
    PlayerMovement1 playerMovement1;
    [SerializeField] GameObject player;

    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject shotgunAmmoBox;
    public AudioSource PickUpSound;
    public GameObject extraCross;
    public GameObject ammoDisplayBox;
    int ammoAmount;
    


    private void Start()
    {
        playerMovement1 = player.GetComponent<PlayerMovement1>();
        ammoAmount = Random.Range(2, 5);
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
            ActionText.GetComponent<Text>().text = "Agarrar";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <=2)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                PickUPAmmo();
                PickUPAmmoUI();
            }
        }
       
    }
    private void OnMouseExit()
    {
        extraCross.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

    void PickUPAmmo()
    {
        ammoDisplayBox.SetActive(true);
        GlobalAmmo.shotgunammoCurrent += ammoAmount;
        shotgunAmmoBox.SetActive(false);
    }

    void PickUPAmmoUI()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        PickUpSound.Play();
        shotgunAmmoBox.SetActive(false);
        extraCross.SetActive(false);
    }
}
