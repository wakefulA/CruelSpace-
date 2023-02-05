using System;
using UnityEngine;

public class EnemyMoveRightLeft : MonoBehaviour
{
    public float moveSpeed ;

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.y -= moveSpeed * Time.fixedDeltaTime;


        transform.position = pos;
    }
}