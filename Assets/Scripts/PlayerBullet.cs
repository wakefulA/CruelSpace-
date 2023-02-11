using System.Collections;
using Lean.Pool;
using UnityEngine;

public class PlayerBullet : MonoBehaviour

{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _lifeTime = 3f;
    [SerializeField] private int _damage = 1;

    private Rigidbody2D _rb;
    private IEnumerator _lifeTimeRoutine;

    [SerializeField] AudioPlayer _audioPlayer;

    private void OnTriggerEnter2D(Collider2D col)
    {
        _audioPlayer = FindObjectOfType<AudioPlayer>();
        
        if (col.gameObject != null && col.gameObject.CompareTag("Enemy")) ;

        EnemyHP enemyHp = col.gameObject.GetComponent<EnemyHP>();

        if (enemyHp != null)
        {
            enemyHp.ApplyDamage(_damage);
        }
        
        
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _rb.velocity = transform.up * _speed;
        _lifeTimeRoutine = LifeTimeTimer();
        StartCoroutine(_lifeTimeRoutine);
    }

    private void OnDisable()
    {
        if (_lifeTimeRoutine != null)
        {
            StopCoroutine(_lifeTimeRoutine);
            _lifeTimeRoutine = null;
        }
    }

    IEnumerator LifeTimeTimer()
    {
        yield return new WaitForSeconds(_lifeTime);
       // Destroy(gameObject);

        Despawn();
    }

    public void Despawn()
    {
        LeanPool.Despawn(gameObject);
    }
}