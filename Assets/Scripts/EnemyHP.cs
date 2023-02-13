using System;
using UnityEngine;

public class EnemyHP : MonoBehaviour

{
    [SerializeField] public int _startHP;
    private Ulta _ulta;
    public GameObject HealthBar;
    public event Action<int> OnHpChanged;

    private Statistics _statistics;

    public int CurrentHp;

    private void Awake()
    {
        CurrentHp = _startHP;
    }

    private void Start()
    {
        _statistics = FindObjectOfType<Statistics>();

        _ulta = FindObjectOfType<Ulta>();
        _ulta._enemyAll.Add(this);
    }

    private void OnDestroy()
    {
        _ulta._enemyAll.Remove(this);
    }

    public void ApplyDamage(int damage)
    {
        CurrentHp = CurrentHp - damage;

        if (CurrentHp <= 0)
        {
            _statistics.ChangeScore(_startHP);
            Destroy(gameObject);
        }

        OnHpChanged?.Invoke(CurrentHp);
        _ulta.AddPecent(5);
    }
}