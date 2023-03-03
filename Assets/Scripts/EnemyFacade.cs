using UnityEngine;

public class EnemyFacade : MonoBehaviour
{
    [SerializeField] private EnemyHp _enemyHp;
    [SerializeField] private EnemyMoveRightLeft _enemyMoveRight;
    [SerializeField] private EnemyAttack _enemyAttack;
    [SerializeField] private CharacterUI _characterUI;
    [SerializeField] private EnemyMoveSin _enemyMoveSin;

    private SpecialForces _specialForces;

    public void ApplyDamage(int damage)
    {
        _enemyHp.ApplyDamage(damage);
        _specialForces.AddPercent(5);
    }

    private void Start()
    {
        _specialForces = FindObjectOfType<SpecialForces>();
        _specialForces._enemyAll.Add(this);
    }

    private void OnDestroy()
    {
        _specialForces._enemyAll.Remove(this);
    }
}