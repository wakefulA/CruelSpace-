using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    
    [SerializeField] public int _startHP;
    

    public int CurrentHp;
    
    
    private void Awake()
    {
        CurrentHp = _startHP;
        
    }
    
    public void ApplyDamage(int damage)
    {
        CurrentHp -= damage;
        
        if (CurrentHp <= 0)
        {
            Destroy(gameObject);
        }

    }
        
}