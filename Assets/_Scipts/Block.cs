using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public bool MinBlock;
    private Rigidbody rb;
    private Material _material;
    [Min(0)]
    public int PointsBlock;
    public float Speed;
    public SnakeGenerator SnakeGenerator;
    public Transform Level { get; private set; }
    public int WaltPoint;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        _material = GetComponent<Renderer>().material;

        LevelGenerator levelGenerator = GetComponentInParent<LevelGenerator>();
        WaltPoint = levelGenerator.MinBlockPoint;
    }
    void Start(){
            if (MinBlock == true)
            {
            PointsBlock =Random.Range(1, WaltPoint-1);
            
            }
            else
            {
                PointsBlock = Random.Range(1, 50);
            }
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
            SnakeGenerator.Breaker();
            SnakeGenerator.PointsSnake--;
            SnakeGenerator.Score++;

        }

     


}
    void RipBlock()
    {
        if(PointsBlock <= 0)
        {
            Destroy(gameObject);

        }
    }
}
