using System;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    public int Points;
    //public int Value = 1;
    
    
    public event Action OnGameOver;
    public event Action OnGameWinn;
    public event Action OnChangeScore;
    
    
    
    private void UpdateStatistic()
    {
        Points = 0;

    }


    public void ChangeScore(int score)
    {
        Points += score;
        OnChangeScore?.Invoke();
    }



}
