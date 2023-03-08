using System;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    [SerializeField] private int _startHP;

    private GameUI _gameUI;

    public int CurrentHp;
    
    
    public event Action<int> OnHPChange; 

    private void Awake()
    {
        CurrentHp = _startHP;
    }

    private void Start()
    {
        _gameUI = FindObjectOfType<GameUI>();
    }

    public void ApplyDamage(int damage)
    {
        CurrentHp = CurrentHp - damage;

        if (CurrentHp <= 0)
        {
            _gameUI.GameOver();
            Destroy(gameObject);
        }
        
        OnHPChange?.Invoke(CurrentHp);
    }
}