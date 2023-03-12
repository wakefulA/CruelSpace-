using System;
using UnityEngine;

public class PlayerHp : MonoBehaviour, IHp
{
    [SerializeField] private int _startHP;

     private GameUi _gameUI;

    private GameOverScreen _gameOverScreen;

    public int CurrentHp;
    
    
    public event Action<int> OnHPChange; 

    private void Awake()
    {
        CurrentHp = _startHP;
    }

    private void Start()
    {
        _gameOverScreen = FindObjectOfType<GameOverScreen>();
        OnHPChange?.Invoke(CurrentHp);
        //_gameUI = FindObjectOfType<GameUi>();
    }

    public void ApplyDamage(int damage)
    {
        CurrentHp = CurrentHp - damage;

        if (CurrentHp <= 0)
        {
            _gameOverScreen.GameOver();
            Destroy(gameObject);
        }
        
        OnHPChange?.Invoke(CurrentHp);
    }
}