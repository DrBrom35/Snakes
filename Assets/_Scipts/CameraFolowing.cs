using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolowing : MonoBehaviour
{

    public Head Head;
    public Vector3 SnakeToCamera;
    public Vector3 Scok;
    [Min(0)]
    public float Volume;

    private void Update()
    {

        Scok.z =  Head.transform.position.z;
   
        transform.position = Scok + SnakeToCamera;
        AudioListener.volume = Volume;
    }
}


