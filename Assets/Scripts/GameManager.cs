using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public enum GameMode { Menu, Play, GameOver }

public class GameManager : MonoBehaviour
{
    public static GameMode Mode = GameMode.Menu;
    public static int AmountOfPickups;
    private static CinemachineImpulseSource _cinemachineImpulse;

    private void Awake()
    {
        _cinemachineImpulse = FindObjectOfType<CinemachineImpulseSource>();
    }

    public static void ShakeCamera()
    {
        _cinemachineImpulse?.GenerateImpulse(0.1f);
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
