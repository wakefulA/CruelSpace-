using System.Collections;
using Lean.Pool;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _lifeTime = 3f;
    [SerializeField] private int _damage = 1;

    private Rigidbody2D _rb;
    private IEnumerator _lifeTimeRoutine;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject != null && col.gameObject.CompareTag("Player")) ;

        PlayerHP playerHp = col.gameObject.GetComponent<PlayerHP>();

        if (playerHp != null)
        {
            playerHp.ApplyDamage(_damage);
        }
        
        
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _rb.velocity = transform.up * _speed * -1;
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

        Despawn();
    }

    private void Despawn()
    {
        LeanPool.Despawn(gameObject);
    }
}