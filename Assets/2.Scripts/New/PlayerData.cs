using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{

    public int health;
    public int healtPacks;

    public bool wasPipePickedUp;

    public bool wasGlockPickedUp;
    public int glockLoadedAmmo;
    public int glockReserveAmmo;

    public bool wasShotgunPickedUp;
    public int shotgunLoadedAmmo;
    public int shotgunReserveAmmo;

    public float[] position;

    public PlayerData(PlayerData player)
    {
        health = GlobalHealth.currentHealth;


        wasGlockPickedUp = PickUpGlock.wasPickedUp;
        glockLoadedAmmo = GlobalAmmo.glockloadedAmmo;
        glockReserveAmmo = GlobalAmmo.glockammoCurrent;

        wasShotgunPickedUp = PickUpShotgun.wasPickedUp;
        shotgunLoadedAmmo = GlobalAmmo.shotgunloadedAmmo;
        shotgunReserveAmmo = GlobalAmmo.shotgunammoCurrent;

        position = new float[3];
        //position[0] = player.transform.position.x;
        //position[1] = player.transform.position.y;
        //position[2] = player.transform.position.z;
    }
}
