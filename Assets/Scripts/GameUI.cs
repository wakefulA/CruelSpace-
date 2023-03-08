using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    private Pause _pause;
    private Statistics _statistics;
    private AudioPlayer _audioPlayer;
    

    [SerializeField] private Button _playerRed;
    [SerializeField] private Button _playerBlue;
    

    [SerializeField] private GameObject _playerPrefabRed;
    [SerializeField] private GameObject _playerPrefabBlue;
    [SerializeField] private GameObject _spawnPlayer;
    [SerializeField] private GameObject _hud;
    [SerializeField] private GameObject _playerImage;
    
    [SerializeField] private GameOverScreen gameOverScreen;

    private void Awake()
    
    {
        _hud.SetActive(false); /// false
        _playerImage.SetActive(true);
        _playerRed.onClick.AddListener(PlayerRedOne);
        _playerBlue.onClick.AddListener(PlayerBlueTwo);
      
    }

    private void Start()
    {
        _pause = FindObjectOfType<Pause>();
        _statistics = FindObjectOfType<Statistics>();
        _audioPlayer = FindObjectOfType<AudioPlayer>();
        Time.timeScale = 0;
    }

    private void PlayerBlueTwo()
    {
        Instantiate(_playerPrefabBlue, _spawnPlayer.transform.position, Quaternion.identity);
        GameOn();
    }

    private void PlayerRedOne()
    {
        Instantiate(_playerPrefabRed, _spawnPlayer.transform.position, Quaternion.identity);
        GameOn();
    }

    public void GameOver()
    {
        _hud.SetActive(false);
        Time.timeScale = 0f;
        gameOverScreen.GameOver();
    }

    private void GameOn()
    {
        _playerImage.SetActive(false);
        _hud.SetActive(true);
        Time.timeScale = 1;
    }
}