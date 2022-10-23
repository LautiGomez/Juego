using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleKey2PickUp : MonoBehaviour
{
    PlayerMovement1 playerMovement1;
    [SerializeField] GameObject player;

    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject extraCross;
    public GameObject puzzleObj;
    public GameObject halfFade;
    public GameObject puzzleText;
    public GameObject uiObj;
    public GameObject objLight;
    public string objDescription;



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
            ActionText.GetComponent<Text>().text = "Agarrar llave";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 2)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                extraCross.SetActive(false);
                GlobalInventory.key2 = true;
                puzzleObj.GetComponent<MeshRenderer>().enabled = false;
                StartCoroutine(PuzzleKey2Picked());
            }
        }

    }
    private void OnMouseExit()
    {
        extraCross.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }
    IEnumerator PuzzleKey2Picked ()
    {
        halfFade.SetActive(true);
        objLight.SetActive(true);
        uiObj.SetActive(true);
        puzzleText.GetComponent<Text>().text = objDescription;
        yield return new WaitForSeconds(4);
        halfFade.SetActive(false);
        uiObj.SetActive(false);
        objLight.SetActive(false);
        puzzleText.GetComponent<Text>().text = "";
        puzzleObj.SetActive(false);
    }


}
