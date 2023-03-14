using System.Collections;
using DefaultNamespace;
using Lean.Pool;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _lifeTime = 3f;
    [SerializeField] public int _damage;
    [SerializeField] private bool _isEnemyBullet;

    private Rigidbody2D _rb;
    private IEnumerator _lifeTimeRoutine;

    private void Awake()
    {
        StartCoroutine(LifeTimeTimer());
        _rb = GetComponent<Rigidbody2D>();
        if (_isEnemyBullet)
        {
            _rb.velocity = transform.up * _speed * -1;
        }

        else
        {
            _rb.velocity = transform.up * _speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (_isEnemyBullet && col.gameObject.CompareTag(Tag.Player))
        {
            {
                IHp ihp = col.gameObject.GetComponentInParent<IHp>();

                if (ihp != null)
                {
                    ihp.ApplyDamage(_damage);
                }
            }
        }

        if (!_isEnemyBullet && col.CompareTag(Tag.Enemy))

        {
            {
                IHp ihp = col.gameObject.GetComponentInParent<IHp>();

                if (ihp != null)
                {
                    ihp.ApplyDamage(_damage);
                }
            }
        }
    }

    //private void OnEnable()
    //{
    //  _rb.velocity = transform.up * _speed * -1;
    //  _lifeTimeRoutine = LifeTimeTimer();
    // StartCoroutine(_lifeTimeRoutine);
    // }

    //private void OnDisable()
    //{
    //if (_lifeTimeRoutine != null)
    //{
    //  StopCoroutine(_lifeTimeRoutine);
    //  _lifeTimeRoutine = null;
    //}
    // }

    IEnumerator LifeTimeTimer()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
        //Despawn();
    }

    private void Despawn()
    {
        LeanPool.Despawn(gameObject);
    }
}