using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Wight;
    public float Speed;
    public float radius;
    public float Height;




    private void Awake()
    {
        Height = Camera.main.orthographicSize;
        Wight = Height*Camera.main.aspect;
    }

    void Update()
    {
        ControlSnake();
        
    }

    void ControlSnake()
    {
        if (Input.GetMouseButton(0))
        {
        Vector3 pos2D=Input.mousePosition;

        pos2D.z=-Camera.main.transform.position.z;

        Vector3 mousePos3d=Camera.main.ScreenToWorldPoint(pos2D);

        Vector3 pos = transform.position;
        pos.x=mousePos3d.x;
        //pos.y=mousePos3d.y;
        transform.position=Vector3.MoveTowards(transform.position,pos,Speed*Mathf.Abs(transform.position.x - pos.x)*Time.deltaTime);
            
       }
        
    }
    private void LateUpdate()
    {
        Vector3 post =transform.position;
        if(post.x> Wight - radius) { post.x = Wight-radius; }

        if(post.x<-Wight+radius) { post.x = -Wight+radius; }

       /* if(post.y> Height - radius) { post.y = Height-radius; }

        if(post.y< -Height+radius) { post.y = -Height+radius; }*/

        transform.position = post;
    }
    
}

