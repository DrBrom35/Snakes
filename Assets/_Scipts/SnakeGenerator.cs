using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGenerator : MonoBehaviour
{

    public GameObject BodiesPart;
    public float DistBody;
    public List<Transform> _bodies;
    public float SpeedBody;
    public int PointsSnake;
    public int Score;
    public float PointsText;
    public LevelGenerator LevelGenerator;
    public Game Game;
    private const string SnakeIndexKey = "SnakeIndex";
    private const string ScoreIndexKey = "ScoreIndex";
    private const string BestScoreIndexKey = "BestScoreIndex";


    private void Awake()
    {
        Score = ScoreIndex;

        
        if (SnakeIndex <= 0)
        {
            PointsSnake = 4;
            for (int i = 0; i < 3; i++)
            {
                var chain = Instantiate(BodiesPart, new Vector3(0, 1, i * -1), Quaternion.identity);
               
                _bodies.Add(chain.transform);
            }
        }
        else
        {
            PointsSnake = SnakeIndex;
            for (int i = 0; i < SnakeIndex-1; i++)
            {
                var chain = Instantiate(BodiesPart, new Vector3(0, 1, i * -1), Quaternion.identity);
                
                _bodies.Add(chain.transform);
            }
        }
    }

    private void Update()
    {
        RipSnake();
        PointsText = PointsSnake;

        
    }

    void FixedUpdate()
    {
        MoveBody();
    }

    private void MoveBody()
    {
        
        Vector3 previosePosition=transform.position;
        foreach (var chain in _bodies)
        {


                Vector3 currectPos=chain.position;
                chain.position=Vector3.MoveTowards(previosePosition,chain.position,SpeedBody+Time.deltaTime);
                previosePosition = currectPos;
                
           
        }
        
    }




    public void Breaker()
    {
        if (_bodies.Count == 0) { return; }

        Destroy(_bodies[_bodies.Count - 1].gameObject);
        _bodies.RemoveAt(_bodies.Count - 1);



    }
    public void RipSnake()
    {
        if (PointsSnake <= -1f)
        {

            this.gameObject.SetActive(false);
            Game.OnSnakeDied();
            SnakeIndex = 0;
            ScoreIndex = 0;
            if (Score > BestScoreIndex)
            {
                BestScoreIndex = Score;
            }

        }
        return;
    }

    public void Level()
    {
        LevelGenerator.CreateWalt();
    }

    public int SnakeIndex
    {
        get => PlayerPrefs.GetInt(SnakeIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(SnakeIndexKey, value);
            PlayerPrefs.Save();
        }
    }
    public int ScoreIndex
    {
        get => PlayerPrefs.GetInt(ScoreIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(ScoreIndexKey, value);
            PlayerPrefs.Save();
        }
    }
    public int BestScoreIndex
    {
        get => PlayerPrefs.GetInt(BestScoreIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(BestScoreIndexKey, value);
            PlayerPrefs.Save();
        }
    }


    public void Snakesave()
    {
        SnakeIndex = PointsSnake;
        ScoreIndex = Score;
        if (Score > BestScoreIndex)
        {
            BestScoreIndex = Score;
        }
    }
}
