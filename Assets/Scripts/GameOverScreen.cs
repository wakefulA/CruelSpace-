using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    private Pause _pause;
    private Statistics _statistics;
    private AudioPlayer _audioPlayer;
    
    
    [SerializeField] private GameObject _gameOverLabel;
    [SerializeField] private GameObject _hud;
    
    [SerializeField] private Button _gameOverExitButton;
    [SerializeField] private Button _gameOverRestartButton;
    
    private void Awake()
    {
        _gameOverLabel.SetActive(false);
        _gameOverExitButton.onClick.AddListener(OnGameOverExitButton);
        _gameOverRestartButton.onClick.AddListener(OnGameOverRestartButton);
    }

    private void Start()
    {
        
        _pause = FindObjectOfType<Pause>();
        _statistics = FindObjectOfType<Statistics>();
        _audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    public void GameOver()
    {
        _hud.SetActive(false);
        _gameOverLabel.SetActive(true);
       _pause.TogglePause();
    }

    private void OnGameOverRestartButton()
    {
        _pause.TogglePause();
        _statistics.UpdateStatistic();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnGameOverExitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}