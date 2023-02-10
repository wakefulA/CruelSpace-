using UnityEngine;

public class EnemyHP : MonoBehaviour

{
    [SerializeField] public int _startHP;

    private Statistics _statistics;
   
    

    public int CurrentHp;
    
    
    private void Awake()
    {
        CurrentHp = _startHP;
        
    }
    
    
    private void Start()
    {
        _statistics = FindObjectOfType<Statistics>();
    }
    
    public void ApplyDamage(int damage)
    {

        CurrentHp = CurrentHp - damage;
        
        if (CurrentHp <= 0)
        {
            _statistics.ChangeScore(_startHP);
            Destroy(gameObject);
        }

    }
}