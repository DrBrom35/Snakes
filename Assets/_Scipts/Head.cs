using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public float Speed;
    public float SpeedHorizontale;
    public Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }
 
    void FixedUpdate()
    {
        rb.velocity = new Vector3(0, 0, Speed);
        ControlSnake();
    }


    void ControlSnake()
    {
        if (Input.GetMouseButton(0))
        {
        Vector3 pos2D=Input.mousePosition;

        pos2D.z=Mathf.Abs(Camera.main.transform.position.z);

        Vector3 mousePos3d=Camera.main.ScreenToWorldPoint(pos2D);

        Vector3 pos = transform.position;
        pos.x=mousePos3d.x;
        rb.AddForce(new Vector3(pos.x*SpeedHorizontale,0,0));
            
       }
        
    }
    


}

