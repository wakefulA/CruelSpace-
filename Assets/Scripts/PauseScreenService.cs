using UnityEngine;
using UnityEngine.UI;

public class PauseScreenService : MonoBehaviour
{
    private Pause _pause;
    private AudioPlayer _audioPlayer;

    [SerializeField] private GameObject _pauseScreen;
   

    [SerializeField] private Button _pauseBackToGameButton;
    [SerializeField] private Button _pauseExitGameButton;

    [SerializeField] private Button _audioOnButton;
    [SerializeField] private Button _audioOffButton;

    private void Awake()
    {
        _pauseScreen.SetActive(false);

        _pauseBackToGameButton.onClick.AddListener(OnPauseBackToGameButton);
        _pauseExitGameButton.onClick.AddListener(OnPauseExitGameButton);

        _audioOnButton.onClick.AddListener(AudioOnButton);
        _audioOffButton.onClick.AddListener(AudioOffButton);
    }

    private void Start()
    {
        _pause = FindObjectOfType<Pause>();
        _pause.OnPaused += Paused;
        _audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    private void AudioOnButton()
    {
        _audioPlayer.soundOff = false;
    }

    private void AudioOffButton()
    {
        _audioPlayer.soundOff = true;
    }

    private void OnDestroy()
    {
        _pause.OnPaused -= Paused;
    }

    private void Paused(bool IsPaused)
    {
        _pauseScreen.SetActive(IsPaused);
    }

    private void OnPauseExitGameButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    private void OnPauseBackToGameButton()
    {
        _pause.TogglePause();
    }
}