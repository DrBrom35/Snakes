using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    private Rigidbody rb;
    private Material _material;
    public int PointsBlock;
    public float Speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        _material = GetComponent<Renderer>().material;

    }

    private void Update()
    {
        RipBlock();
        _material.SetFloat("_gradi", PointsBlock);
    }
    void FixedUpdate()
    {
        rb.velocity =  new Vector3(0,0,Speed);
    }
    private void OnTriggerStay (Collider other)
    {
        if (other.TryGetComponent(out SnakeGenerator SnakeGenerator))
        {
            PointsBlock--;
            SnakeGenerator.PointsSnake--;
            SnakeGenerator.Breaker();
            
        }

        
            
    }
    void RipBlock()
    {
        if(PointsBlock == 0)
        {
            Destroy(gameObject);
        }
    }
}
