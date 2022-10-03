using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public float Wight;
    public float Speed;
    public float radius;
   

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
        pos.y=mousePos3d.y;
        transform.position=Vector3.MoveTowards(transform.position,pos,Speed);
            
       }
        
    }
    private void LateUpdate()
    {
        Vector3 post =transform.position;
        if(post.x> Wight - radius) { post.x = Wight-radius; }

        if(post.x<-Wight+radius) { post.x = -Wight+radius; }

<<<<<<< Updated upstream:Assets/Player.cs
        if(post.y> Height - radius) { post.y = Height-radius; }

        if(post.y< -Height+radius) { post.y = -Height+radius; }

=======
>>>>>>> Stashed changes:Assets/Head.cs
        transform.position = post;
    }
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Vector3 gran=new Vector3(Wight*2, Height*2,0.1f);
        Gizmos.DrawWireCube(Vector3.zero, gran);
    }
}

