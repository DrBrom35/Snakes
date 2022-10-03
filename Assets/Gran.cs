using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gran : MonoBehaviour
{
    public float Wight;
    public float radius;
    
   
    
    private void LateUpdate()
    {
        Vector3 post = transform.position;
        if (post.x > Wight - radius) { post.x = Wight - radius; }

        if (post.x < -Wight + radius) { post.x = -Wight + radius; }

        transform.position = post;
    }
}
