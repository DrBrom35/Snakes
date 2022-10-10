using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walt : MonoBehaviour
{
    public LevelGenerator LevelGenerator;
    
   


   
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out SnakeGenerator SnakeGenerator))
        {
            SnakeGenerator.Level();
            Destroy(gameObject);
        }
    }
}
