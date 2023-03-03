using UnityEngine;

public class PlayerFaсade : MonoBehaviour
{
    [SerializeField] private PlayerHp _playerHp;
    [SerializeField] private PlayerMovement _movement;

  
    
    
    public void ApplyDamage(int damage)
    {
        _playerHp.ApplyDamage(damage);
    }

}