using Lean.Pool;
using UnityEngine;

public class PlayerAttackRed : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPointTransform;
    [SerializeField] private float _fireDelay = 0.3f;

    [SerializeField] private Transform _bulletCenter;

    private AudioPlayer _audioPlayer;

    private Transform _cachedTransform;
    private float _delayTimer;

    private SpecialForces _specialForces;

    private void Awake()
    {
        _cachedTransform = transform;
    }

    private void Start()
    {
        _audioPlayer = FindObjectOfType<AudioPlayer>();
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
        LeanPool.Spawn(_bulletPrefab, _bulletSpawnPointTransform.position, _bulletCenter.rotation);

        _delayTimer = _fireDelay;
        _audioPlayer.AddTheSoundOfAGunshotClip();
    }

    private void TickTimer()
    {
        _delayTimer -= Time.deltaTime;
    }
}