using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndSequence : MonoBehaviour
{
    PlayerMovement1 playerMovement1;
    [SerializeField] GameObject player;

    public float TheDistance;
    public GameObject extraCross;
    public GameObject Sofa;
    public GameObject examineText;
    public GameObject backText;
    public string examineDescription1;
    public bool isExamining = false;
    public Animation finalFade;
    public int sceneToLoad;

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
        yield return new WaitForSeconds(5);
        examineText.GetComponent<Text>().text = "";
        backText.SetActive(false);
        finalFade.Play();
        yield return new WaitForSeconds(2.1f);
        playerMovement1.disable = false;
        PlayerCam.disable = false;
        isExamining = false;
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(sceneToLoad);
    }
}
