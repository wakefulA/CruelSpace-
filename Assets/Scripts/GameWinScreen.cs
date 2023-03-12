using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWinScreen : MonoBehaviour
{
    [Header("Service")]
    [SerializeField] private Pause _pause;
    [SerializeField] private Statistics _statistics;
    [Header("GO")]
    [SerializeField] private GameObject _gameWinLabel;
    [Header("Buttons")]
    [SerializeField] private Button _gameWinExitButton;
    [SerializeField] private Button _gameWinRestartButton;

    private void Awake()
    {
        _gameWinLabel.SetActive(false);
        _gameWinExitButton.onClick.AddListener(OnGameWinExitButton);
        _gameWinRestartButton.onClick.AddListener(OnGameWinRestartButton);
    }

    private void GameWin()
    {
        _gameWinLabel.SetActive(true);
        //_pause.TogglePause();
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