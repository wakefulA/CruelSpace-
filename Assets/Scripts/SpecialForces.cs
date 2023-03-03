using System;
using System.Collections.Generic;
using UnityEngine;

public class SpecialForces : MonoBehaviour
{
    public List<EnemyFacade> _enemyAll;

    public int UltaPercent;

    public event Action<int> OnUltaPercentChoose;

    public void AddPercent(int percent)
    {
        UltaPercent += percent;
        OnUltaPercentChoose?.Invoke(UltaPercent);
    }

    public void Ultra(int damage)
    {
        if (UltaPercent < 100)
        {
            return;
        }

        UltaPercent -= 100;
        OnUltaPercentChoose?.Invoke(UltaPercent);

        int ultadamage = damage * 3;

        foreach (var enemyHp in _enemyAll)
        {
            enemyHp.ApplyDamage(ultadamage);
        }
    }
}