using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterSceneFade : MonoBehaviour
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
    }

    private void Start()
    {
        StartCoroutine(StartSequence());
    }
    IEnumerator StartSequence()
    {
        playerMovement.disable = true;
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = text;
        backText.SetActive(true);
        yield return new WaitForSeconds(10);
        textBox.GetComponent<Text>().text = "";
        fadeScreen.SetActive(false);
        backText.SetActive(false);
        playerMovement.disable = false;
    }
}
