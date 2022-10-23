using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthConsume : MonoBehaviour
{
    public int healingAmount;
    public AudioSource healingSound;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && GlobalInventory.currentAmountHealthPacks > 0)
        {
            if (GlobalHealth.currentHealth > 91)
            {
                GlobalHealth.currentHealth = 100;
            }
            else
            {
                GlobalHealth.currentHealth += healingAmount;
            }
            healingSound.Play();
            GlobalInventory.currentAmountHealthPacks -= 1;
        }
    }
}
