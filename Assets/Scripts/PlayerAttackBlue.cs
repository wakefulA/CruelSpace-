using System;
using Lean.Pool;
using UnityEngine;

public class PlayerAttackBlue : MonoBehaviour
{
    // [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPointTransform;
    [SerializeField] private float _fireDelay = 0.3f;

    [SerializeField] private Transform _bulletRight;
    [SerializeField] private Transform _bulletLeft;
    [SerializeField] private Transform _bulletCenter;

    //private AudioService _audioService;

    private Transform _cachedTransform;
    private float _delayTimer;
    private SpecialForces _specialForces;

    private void Awake()
    {
        _cachedTransform = transform;
    }

    private void Start()
    {
       // _audioService = FindObjectOfType<AudioService>();
        _specialForces = FindObjectOfType<SpecialForces>();
    }

    private void Update()
    {
        TickTimer();
        
        if (CanAttack())
        {
            Attack();
        }
        

        if (Input.GetButton("Fire2"))
        {
            Ulta();
        }
    }

    private void Ulta()
    {
        Bullet _bullet = _bulletPrefab.GetComponent<Bullet>();
        _specialForces.Ultra(_bullet._damage);
    }

    private bool CanAttack()
    {
        return Input.GetButton("Fire1") && _delayTimer <= 0;
    }

    private void Attack()
    {
        
        // _playerAnimation.PlayShoot();
        LeanPool.Spawn(_bulletPrefab, _bulletSpawnPointTransform.position, _bulletRight.rotation);
        LeanPool.Spawn(_bulletPrefab, _bulletSpawnPointTransform.position, _bulletCenter.rotation);
        LeanPool.Spawn(_bulletPrefab, _bulletSpawnPointTransform.position, _bulletLeft.rotation);

        _delayTimer = _fireDelay;
        
        AudioService.Instance.AddTheSoundOfAGunshotClip();
    }

    private void TickTimer()
    {
        _delayTimer -= Time.deltaTime;
    }
}