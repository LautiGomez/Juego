using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AOpening : MonoBehaviour
{
    public GameObject player;
    PlayerMovement1 playerMovement;

    public GameObject fadeScreen;
    public GameObject textBox;
    public GameObject backText;
    public string text;

    // Start is called before the first frame update
    void Awake()
    {
        playerMovement = player.GetComponent<PlayerMovement1>();
        StartCoroutine(StartSequence());
    }

    IEnumerator StartSequence()
    {
        yield return new WaitForSeconds(1.5f);
        textBox.GetComponent<Text>().text = text;
        backText.SetActive(true);
        yield return new WaitForSeconds(5f);
        textBox.GetComponent<Text>().text = "";
        fadeScreen.SetActive(false);
        backText.SetActive(false);
    }

    
}
