using System.Collections;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private GameWinScreen _gameWinScreen;

    [Header("GO")]
    [SerializeField] private GameObject _enemy1;
    [SerializeField] private GameObject _enemy2;
    [SerializeField] private GameObject _enemy3;
    [SerializeField] private GameObject _enemy4;
    [SerializeField] private GameObject _enemy5;
    [SerializeField] private GameObject _enemy6;
    [SerializeField] private GameObject _enemy7;
    [SerializeField] private GameObject _enemy8;

    [SerializeField] private int _enemy1Quality;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(4f);

        for (int i = 0; i < _enemy1Quality; i++)
        {
            Instantiate(_enemy1, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(4f);
        }
    }
}