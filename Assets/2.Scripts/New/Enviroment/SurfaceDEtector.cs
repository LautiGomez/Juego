using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceDEtector : MonoBehaviour
{
    public LayerMask whatIsGround;
    public static bool soft = false;
    public static bool hard = false;
    public static bool metal = false;
    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 5))
        {
            if (hit.transform.gameObject.CompareTag("Soft Surface"))
            {
                soft = true;
                Debug.Log("soft");
            }
            else
            {
                soft = false;
            }
            
            if (hit.transform.gameObject.CompareTag("Hard Surface"))
            {
                hard = true;
                Debug.Log("hard");
            }
            else
            {
                hard = false;
            }
            
            if (hit.transform.gameObject.CompareTag("Metal Surface"))
            {
                metal = true;
                Debug.Log("metal");
            }
            else
            {
                metal = false;
            }
        }
                
        
    }
}
