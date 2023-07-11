using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameMode { Menu, Play, GameOver }

public class GameManager : MonoBehaviour
{
    public static GameMode Mode = GameMode.Menu;
    public static int AmountOfPickups;

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
