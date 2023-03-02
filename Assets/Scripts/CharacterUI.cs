using UnityEngine;

public class CharacterUI : MonoBehaviour
{
    [SerializeField] private HpBar _hpBar;

    [SerializeField] private EnemyHp _enemyHp;

    private void Awake()
    {
        _enemyHp.OnHpChanged += HpChanged;
    }

    private void OnDestroy()
    {
        _enemyHp.OnHpChanged -= HpChanged;

        // if (_health != null)
        //   _health.OnChanged -= HpChanged;
    }

    //   public void Construct(IHealth health)
    //{
    //   _health = health;

    //  if (_health != null)
    // {
    //    _health.OnChanged += HpChanged;
    //   HpChanged(_health.CurrentHp);
    // }
    // }

    private void HpChanged(int currentHp)
    {
        float fillAmount = currentHp / (float) _enemyHp._startHP;
        _hpBar.SetFill(fillAmount);
    }
}