using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWinService : MonoBehaviour
{
    private Pause _pause;
    private Statistics _statistics;
    

    [SerializeField] private GameObject _gameWinLabel;

    [SerializeField] private GameObject _hud;

    [SerializeField] private Button _gameWinExitButton;
    [SerializeField] private Button _gameWinRestartButton;

    private void Awake()
    {
        //_gameWinScreen.SetActive(false);
        _gameWinLabel.SetActive(false);

        _hud.SetActive(true);

        _gameWinExitButton.onClick.AddListener(OnGameWinExitButton);
        _gameWinRestartButton.onClick.AddListener(OnGameWinRestartButton);
    }

    private void Start()
    {
        _pause = FindObjectOfType<Pause>();
        _statistics = FindObjectOfType<Statistics>();
    }

    private void GameWin()
    {
        //_gameWinScreen.SetActive(true);
        _pause.TogglePause();
    }

    private void OnGameWinRestartButton()
    {
        _pause.TogglePause();
        _statistics.UpdateStatistic();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnGameWinExitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}