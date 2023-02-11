using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject Bullet;
    public float BulletSpeed , GunSpeed;
    public Transform ShootPoint;
    Vector2 Direction;
    public LineRenderer line;
    GameObject target;
    public SpringJoint2D spring;
    
    void Start()
    {
        line.enabled = false;
        spring.enabled = false;
    }

    void Update()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move.normalized * GunSpeed * Time.deltaTime; // moving gun and follow camera with cinemachine

        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Direction = MousePos - (Vector2)transform.position;

        FaceMouse();

        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if(Input.GetMouseButtonUp(0))
        {
            reset();
        }

        if(target != null)
        {
            line.SetPosition(0 , ShootPoint.position);
            line.SetPosition(1 , target.transform.position);
        }
        
    }
    void FaceMouse()
    {
        transform.right = Direction;
    }

    void Shoot()
    {
        GameObject BulletIns = Instantiate(Bullet , ShootPoint.position , ShootPoint.rotation);

        BulletIns.GetComponent<Rigidbody2D>().AddForce(transform.right * BulletSpeed);
    }

    public void TargetHit(GameObject hit)
    {
       target = hit;
       line.enabled = true;
       spring.enabled = true;
       spring.connectedBody = target.GetComponent<Rigidbody2D>(); // connect box
    }
    void reset()
    {
       line.enabled = false;
       spring.enabled = false;
       target = null;
    }
}
