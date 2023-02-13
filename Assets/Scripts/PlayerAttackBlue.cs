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

    [SerializeField] private AudioPlayer _audioPlayer;

    private Transform _cachedTransform;
    private float _delayTimer;
    private Ulta _ulta;

    private void Awake()
    {
        _cachedTransform = transform;
    }

    private void Start()
    {
        _ulta = FindObjectOfType<Ulta>();
    }

    private void Update()
    {
        if (CanAttack())
        {
            Attack();
        }

        TickTimer();

        if (Input.GetButton("Fire2"))
        {
            Ulta();
        }
    }

    private void Ulta()
    {
        PlayerBullet playerBullet = _bulletPrefab.GetComponent<PlayerBullet>();
        _ulta.Ultra(playerBullet._damage);
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
        
        _audioPlayer.AddTheSoundOfAGunshotClip();
    }

    private void TickTimer()
    {
        _delayTimer -= Time.deltaTime;
    }
}