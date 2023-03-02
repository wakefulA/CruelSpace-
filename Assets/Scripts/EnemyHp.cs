using System;
using UnityEngine;

public class EnemyHp : MonoBehaviour

{
    [SerializeField] public int _startHP;
    private SpecialForces _specialForces;

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

        _specialForces = FindObjectOfType<SpecialForces>();
        _specialForces._enemyAll.Add(this);
    }

    private void OnDestroy()
    {
        _specialForces._enemyAll.Remove(this);
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
        _specialForces.AddPecent(5);
    }
}