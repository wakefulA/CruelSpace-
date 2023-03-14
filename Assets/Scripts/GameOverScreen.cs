using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    private Pause _pause;
    private Statistics _statistics;
    private AudioService _audioService;
    
    
    [SerializeField] private GameObject _gameOverLabel;
    //[SerializeField] private GameObject _hud;

    [SerializeField] private GameUi _gameUI;
    
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
        _audioService = FindObjectOfType<AudioService>();
    }

    public void GameOver()
    {
        //_hud.SetActive(false);
        _gameOverLabel.SetActive(true);
       _pause.TogglePause();
       _gameUI.ToggleHud();
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