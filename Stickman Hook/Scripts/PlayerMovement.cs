using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    
    void Update()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0); //moving axis X Y
        transform.position += move.normalized * Speed * Time.deltaTime;
    }
}
