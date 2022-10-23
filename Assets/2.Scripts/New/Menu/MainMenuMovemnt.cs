using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuMovemnt : MonoBehaviour
{
    public GameObject mainCamera;
    public string cameraAnim;
    public string pressButtonAnim;
    bool animDone = false;
    public GameObject buttons;
    public GameObject pressButton;
    public AudioSource mainTheme;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && animDone == false)
        {
            pressButton.GetComponent<Animation>().Play(pressButtonAnim);
            mainCamera.GetComponent<Animation>().Play(cameraAnim);
            animDone = true;
            StartCoroutine(MainMenuAppears());
        }
    }
    IEnumerator MainMenuAppears()
    {
        mainTheme.Play();
        yield return new WaitForSeconds(5f);
        buttons.SetActive(true);
    }
}
