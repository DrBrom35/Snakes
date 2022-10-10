using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] WaltPrefab;
    public int CompleteWalt;
    public int MaxWalt;
    public float DistWalt;
    public Transform FinishWalt;
    public Transform Planc;
    public float PlancScale;
    public SnakeGenerator Snake;
    public Game Game;
    public int MinBlockPoint;
    public int RealMaxWalt;


    private void Start()
    {
        RealMaxWalt = MaxWalt + Game.LevelIndex;
    }

    private void Update()
    {
        Planc.localScale =new Vector3(1,1, Snake.transform.position.z + PlancScale);

        MinBlockPoint = Snake.PointsSnake;
        
    }

    public void CreateWalt()
    {
        
        Vector3 Step = new Vector3(4.5f, 1f, Snake.transform.position.z + DistWalt);
        Vector3 StepFinish = new Vector3(0, 4f, Snake.transform.position.z + DistWalt);
        if (CompleteWalt <= RealMaxWalt)
        {
            
            CompleteWalt++;
            Instantiate(WaltPrefab[Random.Range(0, WaltPrefab.Length)], Step, Quaternion.identity,transform);
            Debug.Log("Yeach!");
        }
        else
        {
            Instantiate(FinishWalt, StepFinish, Quaternion.identity,transform);
            Debug.Log("Finish");
        }
    }

}
