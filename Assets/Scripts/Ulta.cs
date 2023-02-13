using System;
using System.Collections.Generic;
using UnityEngine;

public class Ulta : MonoBehaviour
{
    public List<EnemyHP> _enemyAll;

    public int UltaPecent;

    public event Action<int> OnUltaPercentChoose;

    public void AddPecent(int percent)
    {
        UltaPecent += percent;
        OnUltaPercentChoose?.Invoke(UltaPecent);
    }

    public void Ultra(int damage)
    {
        if (UltaPecent < 100)
        {
            return;
        }

        UltaPecent -= 100;
        OnUltaPercentChoose?.Invoke(UltaPecent);

        int ultadamage = damage * 3;

        foreach (var enemyHp in _enemyAll)
        {
            enemyHp.ApplyDamage(ultadamage);
        }
    }
}