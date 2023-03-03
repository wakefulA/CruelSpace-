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
        if (_isEnemyBullet)
        {
            if (col.CompareTag(Tag.Player))

            //if (col.gameObject != null && col.gameObject.CompareTag("Player")) ;
            {
                PlayerFaсade playerFacade = col.gameObject.GetComponentInParent<PlayerFaсade>();

                if (playerFacade != null)
                {
                    playerFacade.ApplyDamage(_damage);
                }
            }
        }

        else
        {
            if (col.CompareTag(Tag.Enemy))
           // if (col.gameObject != null && col.gameObject.CompareTag("Enemy")) ;
            {
                EnemyFacade enemyFacade = col.gameObject.GetComponentInParent<EnemyFacade>();

                if (enemyFacade != null)
                {
                    enemyFacade.ApplyDamage(_damage);
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