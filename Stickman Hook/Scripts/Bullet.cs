using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GunScript gun;
  
    void Start()
    {
       gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<GunScript>(); 
       Invoke("Finish", 2); // bullet destroy after 2 seconds
    }

    void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.tag == "box")
        {
            gun.TargetHit(col.gameObject);
            Destroy(gameObject);
        }
        
    }
    void Finish()
    {
       Destroy(gameObject); 
    }
}
