using System;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    
    [SerializeField] private int _startHP;
    

    public int CurrentHp;
    
 
    
    
    private void Awake()
    {
        CurrentHp = _startHP;
        
    }
    
    public void ApplyDamage(int damage)
    {
        CurrentHp = CurrentHp - damage;
        
        if (CurrentHp <= 0)
        {
            Destroy(gameObject);
        }
        
        

    }
        
}