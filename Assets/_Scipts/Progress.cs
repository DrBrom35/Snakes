using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Progress : MonoBehaviour
{
    private float startZ;
    public float finishZ;
    public Slider Slider;

    public Head Head;
    public LevelGenerator LevelGenerator;

    public float minimumResZ;

    void Start()
    {
        startZ = Head.transform.localPosition.z;
        finishZ = ((LevelGenerator.RealMaxWalt + 2) * 94.4f) + 50;
    }

   
    void Update()
    {
        finishZ = ((LevelGenerator.RealMaxWalt+2)*94.4f)+50;
        minimumResZ = Head.transform.localPosition.z;
        float t = Mathf.InverseLerp(startZ, finishZ, minimumResZ);
        Slider.value  = t;


    }
}
