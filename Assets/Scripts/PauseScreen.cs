using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    private AudioService _audioService;

    [Header("Service")]
    [SerializeField] private Pause _pauseService;
    [Header("GO")]
    [SerializeField] private GameObject _pauseScreen;
    [Header("Button")]
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
        _pauseService.OnPaused += Paused;
        _audioService = FindObjectOfType<AudioService>();
    }

    private void AudioOnButton()
    {
        _audioService.SoundOff = false;
    }

    private void AudioOffButton()
    {
        _audioService.SoundOff = true;
    }

    private void OnDestroy()
    {
        _pauseService.OnPaused -= Paused;
    }

    private void Paused(bool IsPaused)
    {
        _pauseScreen.SetActive(IsPaused);
    }

    private void OnPauseBackToGameButton()
    {
        _pauseService.TogglePause();
    }

    private void OnPauseExitGameButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}