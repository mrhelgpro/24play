using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject _startText;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private ParticleSystem _particleSystem;

    private void Update()
    {
        if (GameManager.Mode == GameMode.Menu)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                GameManager.Play();

                _startText.SetActive(false);
                _particleSystem.Play();
            }
        }

        if (GameManager.Mode == GameMode.GameOver)
        {
            if (_gameOver.activeSelf == false)
            {
                _gameOver.SetActive(true);
                _particleSystem.Stop();
            }
        }
    }

    public void ButtonReloadLevel()
    {
        GameManager.ReloadLevel();
        _gameOver.SetActive(false);
        _startText.SetActive(true);
    }
}
