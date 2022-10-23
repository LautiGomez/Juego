using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpAmmo : MonoBehaviour
{
    PlayerMovement1 playerMovement1;
    [SerializeField] GameObject player;

    public float TheDistance;
    public GameObject ammoBox;
    public AudioSource PickUpSound;
    public GameObject extraCross;
    public GameObject ammoDisplayBox;
    public GameObject mesh;
    int ammoAmount;
    


    private void Start()
    {
        playerMovement1 = player.GetComponent<PlayerMovement1>();
        ammoAmount = Random.Range(4, 8);
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
                mesh.GetComponent<MeshRenderer>().enabled = false;
                PickUPAmmo();
                PickUPAmmoUI();
                StartCoroutine(Wait());
            }
        }
       
    }
    private void OnMouseExit()
    {
        extraCross.SetActive(false);
    }

    void PickUPAmmo()
    {
        ammoDisplayBox.SetActive(true);
        GlobalAmmo.glockammoCurrent += ammoAmount;
        //ammoBox.SetActive(false);
    }

    void PickUPAmmoUI()
    {
        PickUpSound.Play();
        //ammoBox.SetActive(false);
        extraCross.SetActive(false);
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4.01f);
        ammoBox.SetActive(false);
    }
}
