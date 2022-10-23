using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{

    PlayerMovement1 playerMovement1;
    [SerializeField] GameObject player;
    public AudioSource hardStepsSound;
    public AudioSource hardSprintSound;
    /*
    public AudioSource softStepSound;
    public AudioSource softSprintSound;
    public AudioSource metalStepSound;
    public AudioSource metalsprintSound;
    */

    private void Start()
    {
        playerMovement1 = player.GetComponent<PlayerMovement1>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                hardStepsSound.enabled = false;
                hardSprintSound.enabled = true;
            }
            else
            {
                hardStepsSound.enabled = true;
                hardSprintSound.enabled = false;
            }
        }
        else
        {
            hardStepsSound.enabled = false;
            hardSprintSound.enabled = false;
        }
        /*
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) && playerMovement1.disable == false && SurfaceDEtector.soft == true)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                softStepSound.enabled = false;
                softSprintSound.enabled = true;
            }
            else
            {
                softStepSound.enabled = true;
                softSprintSound.enabled = false;
            }
        }
        else
        {
            softStepSound.enabled = false;
            softSprintSound.enabled = false;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) && playerMovement1.disable == false && SurfaceDEtector.metal == true)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                metalStepSound.enabled = false;
                metalsprintSound.enabled = true;
            }
            else
            {
                metalStepSound.enabled = true;
                metalsprintSound.enabled = false;
            }
        }
        else
        {
            metalStepSound.enabled = false;
            metalsprintSound.enabled = false;
        }
        */
    }
}
