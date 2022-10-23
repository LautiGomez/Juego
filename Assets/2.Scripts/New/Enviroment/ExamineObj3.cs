using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExamineObj3 : MonoBehaviour
{
    PlayerMovement1 playerMovement1;
    [SerializeField] GameObject player;

    public float TheDistance;
    public GameObject extraCross;
    public GameObject theObj;
    public GameObject examineText;
    public GameObject backText;
    public string examineDescription1;
    public string examineDescription2;
    public string examineDescription3;
    public bool isExamining = false;

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
            if (TheDistance <= 2 && isExamining == false)
            {
                extraCross.SetActive(false);
                StartCoroutine(ObjExaming());
            }
        }

    }
    private void OnMouseExit()
    {
        extraCross.SetActive(false);
    }

    IEnumerator ObjExaming()
    {
        playerMovement1.disable = true;
        PlayerCam.disable = true;
        isExamining = true;
        backText.SetActive(true);
        examineText.GetComponent<Text>().text = examineDescription1;
        yield return new WaitForSeconds(3);
        examineText.GetComponent<Text>().text = examineDescription2;
        yield return new WaitForSeconds(3);
        examineText.GetComponent<Text>().text = examineDescription3;
        yield return new WaitForSeconds(3);
        examineText.GetComponent<Text>().text = "";
        playerMovement1.disable = false;
        PlayerCam.disable = false;
        backText.SetActive(false);
        isExamining = false;
    }
}
