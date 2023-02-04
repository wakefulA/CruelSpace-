using System;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public event Action<bool> OnPaused; 

    public bool IsPaused { get; private set; }
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }

    // public void GameStop()
    // {
    // if (GameManager.Instance._isStarted == false)
    //   {
    //       return;
    //    }

    //    Time.timeScale = 0;
    //  }


    #region Private methods

    public void TogglePause()
    {
        IsPaused = !IsPaused;
        Time.timeScale = IsPaused ? 0 : 1;
        OnPaused?.Invoke((IsPaused));
    }

    #endregion
}