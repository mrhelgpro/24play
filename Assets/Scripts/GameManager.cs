using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameMode { Menu, Play, GameOver }
    public static GameMode Mode = GameMode.Menu;

    private void Update()
    {
        if (Mode == GameMode.Menu)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Play();
            }
        }

        if (Mode == GameMode.GameOver)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                ReloadLevel();
            }
        }
    }

    public static void ReloadLevel()
    {
        SceneManager.LoadScene(0);
        Mode = GameMode.Menu;
    }

    public static void Play()
    {
        Mode = GameMode.Play;
    }

    public static void GameOver()
    {
        Mode = GameMode.GameOver;
    }
}
