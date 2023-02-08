using System.Collections;
using Lean.Pool;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPointTransform;
    [SerializeField] private float _currentTimeSpawn = 0.3f;
    [SerializeField] private float _startTimeSpawn = 3f;

    
    private Transform _cachedTransform;
    private float _delayTimer;

    private void Awake()
    {
        _cachedTransform = transform;
    }

    
    private void Start()
    {
        StartCoroutine(SpawnWeaponRoutine());
    }

    // private bool CanAttack()
    //{
     //   return Input.GetButton("Fire1") && _delayTimer <= 0;
   // }
   
   

    private void Attack()
    {
        // _playerAnimation.PlayShoot();
        LeanPool.Spawn(_bulletPrefab, _bulletSpawnPointTransform.position, _cachedTransform.rotation);
        
        
        _delayTimer = _currentTimeSpawn;
    }


    private IEnumerator SpawnWeaponRoutine()
    {
        yield return new WaitForSeconds(_startTimeSpawn);

        while (true)
        {
            Attack();

            yield return new WaitForSeconds(_currentTimeSpawn);
        }

    }

}