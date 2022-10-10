using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public SnakeGenerator SnakeGenerator;
    public GameObject LoseMenu;
    public GameObject WinMenu;
    private const string LevelIndexKey = "LevelIndex";

    public enum State
    {
        Playing,
        Lose,
        Win,
    }
    public State CurrectState { get; private set; }

    public void OnSnakeDied()
    {
        if (CurrectState != State.Playing) return;

        CurrectState = State.Lose;
        Debug.Log("Game over");
        LoseMenu.SetActive(true);
    }

    public void ReseachSnakeOnFinish()
    {
        if (CurrectState != State.Playing) return;

        CurrectState = State.Win;
        LevelIndex++;
        SnakeGenerator.Snakesave();
        Debug.Log("Win");
        WinMenu.SetActive(true);
        
    }



    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }

    public void Reloved()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
        

}
