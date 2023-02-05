using UnityEngine;

public class MoveSin : MonoBehaviour
{


    [SerializeField] private float _amplitude;
    [SerializeField] private float _frequency;

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float sin = Mathf.Sin(pos.y * _frequency) * _amplitude;

        pos.x = sin;

        transform.position = pos;
    }
}