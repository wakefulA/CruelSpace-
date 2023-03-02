using System;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private int _startHP;

    private UIController _uiController;

    public int CurrentHp;
    
    
    public event Action<int> OnHPChange; 

    private void Awake()
    {
        CurrentHp = _startHP;
    }

    private void Start()
    {
        _uiController = FindObjectOfType<UIController>();
    }

    public void ApplyDamage(int damage)
    {
        CurrentHp = CurrentHp - damage;

        if (CurrentHp <= 0)
        {
            _uiController.GameOver();
            Destroy(gameObject);
        }
        
        OnHPChange?.Invoke(CurrentHp);
    }
}