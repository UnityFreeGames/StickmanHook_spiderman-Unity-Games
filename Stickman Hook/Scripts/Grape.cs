using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grape : MonoBehaviour
{
    private Camera _camera;
    private Vector3 mousepos;
    private bool check;
    private DistanceJoint2D distancejoin;
    private LineRenderer linerender;
    private Vector3 tempPose;
    [SerializeField] LayerMask grapmask;


    void Start()
    {
        _camera = Camera.main;
        distancejoin = GetComponent<DistanceJoint2D>();
        linerender = GetComponent<LineRenderer>();

        distancejoin.enabled = false;
        linerender.enabled = false;

        check = true;  
        
    }

    void Update()
    {
        Getmouse();

        RaycastHit2D hitray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition) , Vector2.zero , Mathf.Infinity , grapmask);

        if(Input.GetMouseButtonDown(0) && check && hitray)
        {
            linerender.enabled = true;
            distancejoin.enabled = true;
            distancejoin.connectedAnchor = mousepos;   //settup hook       
            tempPose = mousepos;
            check = false;
        }
        else if(Input.GetMouseButtonDown(0))
        {
            distancejoin.enabled = false;
            check = true;
            linerender.enabled = false;
        }

        Drawline();
        
    }

    void Drawline()
    {
       if(!linerender.enabled) return;
       linerender.SetPosition(0 , transform.position);
       linerender.SetPosition(1 , new Vector3(tempPose.x , tempPose.y , 0));
    }
    void Getmouse()
    {
        mousepos = _camera.ScreenToWorldPoint(Input.mousePosition);
    }
}
