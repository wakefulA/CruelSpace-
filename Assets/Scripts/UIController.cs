using System;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

   private Pause _pause;
   private Statistics _statistics;
   
   [SerializeField] private GameObject _pauseScreen;
   [SerializeField] private GameObject _gameWinScreen;
   [SerializeField] private GameObject _gameOverScreen;
   [SerializeField] private GameObject _hud;

   [SerializeField] private Button _pauseBackToGameButton;
   [SerializeField] private Button _pauseExitGameButton;
   [SerializeField] private Button _gameOverExitButton;
   [SerializeField] private Button _gameOverRestartButton;
   [SerializeField] private Button _gameWinExitButton;
   [SerializeField] private Button _gameWinRestartButton;
   
   private void Awake()
   {
      _gameWinScreen.SetActive(false);
      _gameOverScreen.SetActive(false);
      _pauseScreen.SetActive(false);
      _hud.SetActive(true);

      _pauseBackToGameButton.onClick.AddListener(OnPauseBackToGameButton);
      _pauseExitGameButton.onClick.AddListener(OnPauseExitGameButton);
      _gameOverExitButton.onClick.AddListener(OnGameOverExitButton);
      _gameOverRestartButton.onClick.AddListener(OnGameOverRestartButton);
      _gameWinExitButton.onClick.AddListener(OnGameWinExitButton);
      _gameWinRestartButton.onClick.AddListener(OnGameWinRestartButton);
      
      
   }

   private void Start()
   {
      _pause = FindObjectOfType<Pause>();
      _pause.OnPaused += Paused;
      _statistics = FindObjectOfType<Statistics>();
      _statistics.OnGameOver += GameOver;
      _statistics.OnGameWinn += GameWin;
     
   }

   private void OnDestroy()
   {
      _pause.OnPaused -= Paused;
      _statistics.OnGameOver -= GameOver;
      _statistics.OnGameWinn -= GameWin;
   }

   private void Paused(bool IsPaused)
   {
      _pauseScreen.SetActive(IsPaused);
   }

   private void GameWin()
   {
      _gameWinScreen.SetActive(true);  
      _pause.TogglePause();
   
   }

   private void GameOver()
   { 
      _gameOverScreen.SetActive(true);
      _pause.TogglePause();
    
   }

   private void OnGameWinRestartButton()
   {
      throw new NotImplementedException();
   }

   private void OnGameWinExitButton()
   {
      throw new NotImplementedException();
   }

   private void OnGameOverRestartButton()
   {
      throw new NotImplementedException();
   }

   private void OnGameOverExitButton()
   {
      throw new NotImplementedException();
   }

   private void OnPauseExitGameButton()
   {
      throw new NotImplementedException();
   }

   private void OnPauseBackToGameButton()
   {
      _pauseScreen.SetActive(false);
      Time.timeScale = 1f;
   }
   
   
   

}
