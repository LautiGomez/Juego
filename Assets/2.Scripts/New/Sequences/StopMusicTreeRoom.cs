using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusicTreeRoom : MonoBehaviour
{
    PlayerMovement1 playerMovement1;
    [SerializeField] GameObject player;

    public float TheDistance;
    public GameObject Origin;

    public AudioSource music;


    void OnMouseOver()
    {
        if (Input.GetButtonDown("Action") && TheDistance <= 2)
        {
            music.Stop();
        }
    }
}
