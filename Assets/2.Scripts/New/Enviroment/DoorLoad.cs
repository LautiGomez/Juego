using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorLoad : MonoBehaviour
{
    PlayerMovement1 playerMovement1;
    [SerializeField] GameObject player;

    public float TheDistance;
 
    public GameObject Door;
    public AudioSource doorSound;

    public GameObject extraCross;
    public Animation doorFade;
    public bool isPressed = false;
    //public int sceneToLoad;

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
            if (TheDistance <=2 && isPressed ==false)
            {
                StartCoroutine(LoadScene());
            }
        }
       
    }
    private void OnMouseExit()
    {
        extraCross.SetActive(false);
    }

    IEnumerator LoadScene()
    {
        doorSound.Play();
        playerMovement1.disable = true;
        isPressed = true;
        doorFade.Play("DoorFade");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
