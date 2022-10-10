using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuText : MonoBehaviour
{
    public Text Text;
    public Text Level;
    public Text Level1;
    public Text LevelLevelComplete;
    public Text ScoreText;
    public Text BestScore;
    public Text BestScoreLose;
    public Text ScoreLose;
    public Game Game;
    public SnakeGenerator SnakeGenerator;

    private void Start()
    {
        
        Text.text = "Level " + (Game.LevelIndex + 1).ToString();
        Level.text = (Game.LevelIndex + 1).ToString();
        Level1.text = (Game.LevelIndex + 2).ToString();
        LevelLevelComplete.text= "Level " + (Game.LevelIndex + 1).ToString() + " passed";


    }

    private void Update()
    {
        ScoreText.text = SnakeGenerator.Score.ToString();
        BestScore.text= "Best score : "+SnakeGenerator.BestScoreIndex.ToString();
        BestScoreLose.text= "Best score: "+SnakeGenerator.BestScoreIndex.ToString();
        ScoreLose.text= "You score: " + SnakeGenerator.Score.ToString();

    }
}


