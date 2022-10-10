using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Food : MonoBehaviour
{
    [Min(0)]
    public int FoodPoints;
    public TMP_Text Text;
    public GameObject Body;
    public List<Transform> _food;

    private void Awake()
    {
        FoodPoints = Random.Range(1, 5);
        Text.text = FoodPoints.ToString();
        for (int i = 0; i < FoodPoints; i++)
        {
            var chain=Instantiate(Body,new Vector3(0,0,i*-1),Quaternion.identity);
            _food.Add(chain.transform);   
        }  
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out SnakeGenerator SnakeGenerator))
        {
            SnakeGenerator._bodies.AddRange(_food);
            SnakeGenerator.PointsSnake = SnakeGenerator.PointsSnake + _food.Count;
            Destroy(gameObject);
        }
        return;

    }
}
