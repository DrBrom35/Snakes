using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    private Rigidbody rb;
    public int PointsBlock;
    public float Speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    void FixedUpdate()
    {
        rb.velocity =  new Vector3(0,0,Speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out SnakeGenerator SnakeGenerator))
            PointsBlock--;
        SnakeGenerator.Breaker();
    }

}
