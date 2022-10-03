using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Food : MonoBehaviour
{
    public int FoodPoints;
    public TMP_Text Text;
    public GameObject Body;
    public List<Transform> _food;

    private void Awake()
    {
        Text.text = FoodPoints.ToString();
        for (int i = 0; i < FoodPoints; i++)
        {
            var chain=Instantiate(Body);
            _food.Add(chain.transform);   
        }  
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out SnakeGenerator SnakeGenerator))
        {
            SnakeGenerator._bodies.AddRange(_food);
            Destroy(gameObject);
        }

    }
}
